#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagePipe;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;

using mxProject.Tools.DataFountain.Messaging;
using mxProject.Tools.DataFountain.Models;
using mxProject.Tools.DataFountain.Forms.FieldEditors;
using mxProject.Tools.DataFountain.Forms.FieldEditors.TupleFields;
using mxProject.Tools.DataFountain.Executions;
using mxProject.Tools.DataFountain.Configurations;

namespace mxProject.Tools.DataFountain.Forms
{

    /// <summary>
    /// Data generator editor.
    /// </summary>
    internal partial class DataGeneratorEditorForm : Form
    {

        #region ctor

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal DataGeneratorEditorForm(DataFountainContext context)
        {
            InitializeComponent();

            m_Context = context;

            Init();
        }

        #endregion

        private readonly DataFountainContext m_Context = null!;

        /// <summary>
        /// Executes initial processing.
        /// </summary>
        private void Init()
        {
            InitMenu();
            InitFieldTree();
            InitMessaging();
            InitPreview();
            InitOutputCsv();
            InitDisposal();

            this.Load += (sender, e) =>
            {
                if (CurrentProjectSettings == null) { NewProject(); }
            };
        }

        #region dispose

        /// <summary>
        /// Executes initial processing related to disposal.
        /// </summary>
        private void InitDisposal()
        {

            this.Disposed += (sender, e) =>
            {
                m_DisposableObjects.ForEach(x => x?.Dispose());
            };

        }

        private readonly List<IDisposable> m_DisposableObjects = new List<IDisposable>();

        private T AddDisposableObject<T>(T obj) where T : IDisposable
        {
            m_DisposableObjects.Add(obj);
            return obj;
        }

        #endregion

        #region showDialog

        /// <summary>
        /// Shows as a modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        internal DialogResult ShowDialog(IWin32Window owner, DataFountainProjectSettings settings)
        {
            try
            {
                CurrentProjectSettings = settings;

                this.CurrentDataGeneratorSettings = new DataGeneratorSettingsState(settings.DataGeneratorSettings!);

                return ShowDialog(owner);
            }
            finally
            {
                this.CurrentDataGeneratorSettings = null;
                CurrentProjectSettings = null;
            }
        }

        #endregion

        #region menu

        /// <summary>
        /// Executes initial processing related to the menus.
        /// </summary>
        private void InitMenu()
        {
            mnuNewProject.Click += (sender, e) =>
            {
                NewProject();
            };

            mnuLoadProjectSettings.Click += (sender, e) =>
            {
                if (FormUtility.ShowProjectOpenFileDialog(CurrentProjectFilePath, out string selectedPath) != DialogResult.OK) { return; }

                try
                {
                    LoadProjectFile(selectedPath);
                }
                catch (Exception ex)
                {
                    FormUtility.ShowErrorMessageBox(this, ex.Message);
                }
            };

            mnuSaveAsProjectSettings.Click += (sender, e) =>
            {
                if (FormUtility.ShowProjectSaveFileDialog(CurrentProjectFilePath, out string selectedPath) != DialogResult.OK) { return; }

                try
                {
                    SaveProjectFile(selectedPath);
                }
                catch (Exception ex)
                {
                    FormUtility.ShowErrorMessageBox(this, ex.Message);
                }
            };

            mnuLoadDataGeneratorSettings.Click += (sender, e) =>
            {
                if (FormUtility.ShowGeneratorOpenFileDialog(CurrentDataGeneratorFilePath, out string selectedPath) != DialogResult.OK) { return; }

                try
                {
                    LoadDataGeneratorFile(selectedPath);
                }
                catch (Exception ex)
                {
                    FormUtility.ShowErrorMessageBox(this, ex.Message);
                }
            };

            mnuSaveAsDataGeneratorSettings.Click += (sender, e) =>
            {
                if (FormUtility.ShowGeneratorSaveFileDialog(CurrentDataGeneratorFilePath, out string? selectedPath) != DialogResult.OK) { return; }

                try
                {
                    SaveDataGeneratorFile(selectedPath);
                }
                catch (Exception ex)
                {
                    FormUtility.ShowErrorMessageBox(this, ex.Message);
                }
            };

            mnuExecutorSetup.Click += (sender, e) =>
            {
                using ExecutorSetupForm form = new();

                if (form.ShowDialog(this, CurrentExecutorSettings) != DialogResult.OK) { return; }

                m_Context.SetupExecutor(CurrentExecutorSettings.CreateSetupArgs());
            };

            mnuCsvSettings.Click += (sender, e) =>
            {
                using CsvSettingsForm form = new();

                form.ShowDialog(this, CurrentCsvSettings);
            };

            mnuVersion.Click += (sender, e) =>
            {
                using VersionForm form = new();

                form.ShowDialog(this);
            };
        }

        #endregion

        #region project settings

        /// <summary>
        /// Opens a new project.
        /// </summary>
        private void NewProject()
        {
            var settings = new DataFountainProjectSettings();

            m_CurrentProjectFilePath = null;
            m_CurrentDataGeneratorFilePath = null;
            CurrentProjectSettings = settings;
        }

        /// <summary>
        /// Loads the specified project file.
        /// </summary>
        /// <param name="filePath"></param>
        private void LoadProjectFile(string filePath)
        {
            var setting = DataFountainProjectSettings.Deserialize(filePath);

            m_CurrentProjectFilePath = filePath;
            m_CurrentDataGeneratorFilePath = null;
            CurrentProjectSettings = setting;
        }

        /// <summary>
        /// Saves the current project to the specified project file.
        /// </summary>
        /// <param name="filePath"></param>
        private void SaveProjectFile(string filePath)
        {
            DataFountainProjectSettings settings;

            if (CurrentProjectSettings == null)
            {
                settings = new DataFountainProjectSettings();
            }
            else
            {
                settings = (DataFountainProjectSettings)CurrentProjectSettings.Clone();
            }

            settings.DataGeneratorSettings = CurrentDataGeneratorSettings?.CreateSettings();
            settings.CsvSettings = null ?? new CsvSettings();
            settings.ExecutorSettings = (ExecutorSettings)CurrentExecutorSettings.Clone();

            settings.Serialize(filePath);
        }

        /// <summary>
        /// Gets the current project file.
        /// </summary>
        private string? CurrentProjectFilePath
        {
            get { return m_CurrentProjectFilePath; }
        }
        private string? m_CurrentProjectFilePath;

        /// <summary>
        /// Gets or sets the current project settings.
        /// </summary>
        private DataFountainProjectSettings? CurrentProjectSettings
        {
            get { return m_CurrentProjectSettings; }
            set
            {
                m_CurrentProjectSettings = value;
                OnCurrentProjectSettingsChanged();
            }
        }
        private DataFountainProjectSettings? m_CurrentProjectSettings = null!;

        /// <summary>
        /// Executed when the value of <see cref="CurrentProjectSettings"/> property changes.
        /// </summary>
        private void OnCurrentProjectSettingsChanged()
        {
            this.CurrentDataGeneratorSettings = new DataGeneratorSettingsState(CurrentProjectSettings?.DataGeneratorSettings ?? new Devs.DataGeneration.Configuration.DataGeneratorSettings());

            static string? GetFileName(string? filePath)
            {
                if (string.IsNullOrEmpty(filePath)) { return null; }
                return System.IO.Path.GetFileName(filePath);
            }

            this.Text = $"mxDataFountain [{GetFileName(CurrentProjectFilePath) ?? "New Project"}]";

            m_Context.SetupExecutor(CurrentExecutorSettings.CreateSetupArgs());
        }

        private ExecutorSettings CurrentExecutorSettings
        {
            get
            {
                if (CurrentProjectSettings == null)
                {
                    CurrentProjectSettings = new DataFountainProjectSettings();
                }
                if (CurrentProjectSettings.ExecutorSettings == null)
                {
                    CurrentProjectSettings.ExecutorSettings = new ExecutorSettings();
                }
                return CurrentProjectSettings.ExecutorSettings;
            }
        }

        private CsvSettings CurrentCsvSettings
        {
            get
            {
                if (CurrentProjectSettings == null)
                {
                    CurrentProjectSettings = new DataFountainProjectSettings();
                }
                if (CurrentProjectSettings.CsvSettings == null)
                {
                    CurrentProjectSettings.CsvSettings = new CsvSettings();
                }
                return CurrentProjectSettings.CsvSettings;
            }
        }

        #endregion

        #region generator settings

        /// <summary>
        /// Loads the specified generator file.
        /// </summary>
        /// <param name="filePath"></param>
        private void LoadDataGeneratorFile(string filePath)
        {
            using System.IO.FileStream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
            using System.IO.StreamReader reader = new System.IO.StreamReader(stream, Encoding.UTF8);

            var json = reader.ReadToEnd();

            var settings = (DataGeneratorSettings)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(DataGeneratorSettings), DataFountainProjectSettings.GetJsonConverters())!;

            m_CurrentDataGeneratorFilePath = filePath;
            CurrentDataGeneratorSettings = new DataGeneratorSettingsState(settings);
        }

        /// <summary>
        /// Saves the current generator to the specified generator file.
        /// </summary>
        /// <param name="filePath"></param>
        private void SaveDataGeneratorFile(string filePath)
        {
            var json = CurrentDataGeneratorSettings?.CreateSettingsJson(true);

            using System.IO.FileStream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
            using System.IO.StreamWriter writer = new System.IO.StreamWriter(stream, Encoding.UTF8);

            writer.WriteLine(json);
        }

        /// <summary>
        /// Gets or sets the current generator file.
        /// </summary>
        private string? CurrentDataGeneratorFilePath
        {
            get { return m_CurrentDataGeneratorFilePath; }
        }
        private string? m_CurrentDataGeneratorFilePath;

        /// <summary>
        /// Gets or sets the current generator settings.
        /// </summary>
        private DataGeneratorSettingsState? CurrentDataGeneratorSettings
        {
            get { return m_CurrentDataGeneratorSettings; }
            set
            {
                if (m_CurrentDataGeneratorSettings == value) { return; }
                m_CurrentDataGeneratorSettings = value;
                OnDataGeneratorSettingsChanged();
            }
        }
        private DataGeneratorSettingsState? m_CurrentDataGeneratorSettings;

        /// <summary>
        /// Executed when the value of <see cref="CurrentDataGeneratorSettings"/> property changes.
        /// </summary>
        private void OnDataGeneratorSettingsChanged()
        {
            ShowDataGeneratorSettings(CurrentDataGeneratorSettings);
        }

        /// <summary>
        /// Shows the specified generator settings.
        /// </summary>
        /// <param name="settings"></param>
        private void ShowDataGeneratorSettings(DataGeneratorSettingsState? settings)
        {
            FieldEditor = null;
            m_FieldTree.ClearAllFields();

            if (settings != null)
            {
                m_FieldTree.AddAllFields(settings);
            }

            m_FieldTree.TreeView.ExpandAll();
        }

        #endregion

        #region field tree

        private FieldTree m_FieldTree = null!;

        /// <summary>
        /// Executes initial processing related to the field tree.
        /// </summary>
        private void InitFieldTree()
        {
            m_FieldTree = AddDisposableObject(new FieldTree(treeFields, m_Context));
        }

        /// <summary>
        /// Gets or sets the field editor.
        /// </summary>
        private UserControl? FieldEditor
        {
            get { return m_FieldEditor; }
            set
            {
                if (m_FieldEditor == value) { return; }

                UserControl? prev = m_FieldEditor;

                if (m_FieldEditor != null)
                {
                    this.pnlBody.Panel2.Controls.Remove(m_FieldEditor);
                }

                m_FieldEditor = value;

                if (m_FieldEditor != null)
                {
                    this.pnlBody.Panel2.Controls.Add(m_FieldEditor);
                }

                prev?.Dispose();
            }
        }
        private UserControl? m_FieldEditor;

        /// <summary>
        /// Field tree.
        /// </summary>
        private class FieldTree : IDisposable
        {
            internal FieldTree(TreeView tree, DataFountainContext context)
            {
                TreeView = tree;
                m_Context = context;

                tree.ImageList = IconImageList.Singleton.ImageList;
                tree.HideSelection = false;

                FieldNode = new FieldKindNode(DataGeneratorFieldKind.Field);
                TupleFieldNode = new FieldKindNode(DataGeneratorFieldKind.TupleField);
                AdditionalFieldNode = new FieldKindNode(DataGeneratorFieldKind.AdditionalField);
                AdditionalTupleFieldNode = new FieldKindNode(DataGeneratorFieldKind.AdditionalTupleField);

                FieldNode.ContextMenuStrip = AddDisposableObject(CreateFieldNodeMenu());
                TupleFieldNode.ContextMenuStrip = AddDisposableObject(CreateTupleFieldNodeMenu());
                AdditionalFieldNode.ContextMenuStrip = AddDisposableObject(CreateAdditionalFieldNodeMenu());
                AdditionalTupleFieldNode.ContextMenuStrip = AddDisposableObject(CreateAdditionalTupleFieldNodeMenu());

                tree.Nodes.Add(FieldNode);
                tree.Nodes.Add(TupleFieldNode);
                tree.Nodes.Add(AdditionalFieldNode);
                tree.Nodes.Add(AdditionalTupleFieldNode);

                tree.AfterSelect += (sender, e) => 
                {
                    if (tree.SelectedNode is FieldNode node)
                    {
                        m_Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.Selected, node.FieldSettings);
                    }
                };

                tree.MouseClick += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        tree.SelectedNode = tree.GetNodeAt(e.Location);
                    }
                };
            }

            public void Dispose()
            {
                foreach (var obj in m_Disposables)
                {
                    obj.Dispose();
                }
            }

            private T AddDisposableObject<T>(T disposable) where T : IDisposable
            {
                if (disposable == null) { return disposable!; }

                m_Disposables.Add(disposable);
                return disposable;
            }

            private readonly List<IDisposable> m_Disposables = new();

            private readonly DataFountainContext m_Context;

            /// <summary>
            /// Gets the tree view.
            /// </summary>
            internal TreeView TreeView { get; }

            /// <summary>
            /// Gets the field node.
            /// </summary>
            internal FieldKindNode FieldNode { get; }

            /// <summary>
            /// Gets the tuple field node.
            /// </summary>
            internal FieldKindNode TupleFieldNode { get; }

            /// <summary>
            /// Gets the additional field node.
            /// </summary>
            internal FieldKindNode AdditionalFieldNode { get; }

            /// <summary>
            /// Gets the additional tuple field node.
            /// </summary>
            internal FieldKindNode AdditionalTupleFieldNode { get; }

            /// <summary>
            /// Clears all the fields in this tree.
            /// </summary>
            internal void ClearAllFields()
            {
                FieldNode.Nodes.Clear();
                TupleFieldNode.Nodes.Clear();
                AdditionalFieldNode.Nodes.Clear();
                AdditionalTupleFieldNode.Nodes.Clear();
            }

            /// <summary>
            /// Adds all the fields defined in the specified generator settings.
            /// </summary>
            /// <param name="settings"></param>
            internal void AddAllFields(DataGeneratorSettingsState settings)
            {
                ClearAllFields();

                if (settings != null)
                {
                    foreach (var field in settings.Fields)
                    {
                        AddFieldNode(field);
                    }

                    foreach (var field in settings.TupleFields)
                    {
                        var node = AddFieldNode(field);

                        if (field is DirectProductFieldSettingsState directProduct)
                        {
                            foreach (var innerField in directProduct.CreateInnerFields())
                            {
                                AddDirectProductInnerFieldNode(innerField);
                            }
                        }
                    }

                    foreach (var field in settings.AdditionalFields)
                    {
                        AddFieldNode(field);
                    }

                    foreach (var field in settings.AdditionalTupleFields)
                    {
                        AddFieldNode(field);
                    }
                }
            }

            /// <summary>
            /// Gets the node that corresponds to the specified field kind.
            /// </summary>
            /// <param name="fieldKind"></param>
            /// <returns></returns>
            /// <exception cref="NotSupportedException">
            /// </exception>
            private FieldKindNode GetFieldKindNode(DataGeneratorFieldKind fieldKind)
            {
                return fieldKind switch
                {
                    DataGeneratorFieldKind.Field => FieldNode,
                    DataGeneratorFieldKind.TupleField => TupleFieldNode,
                    DataGeneratorFieldKind.AdditionalField => AdditionalFieldNode,
                    DataGeneratorFieldKind.AdditionalTupleField => AdditionalTupleFieldNode,
                    _ => throw new NotSupportedException()
                };
            }

            /// <summary>
            /// Adds the node associated with the specified field.
            /// </summary>
            /// <param name="settings"></param>
            /// <returns></returns>
            internal FieldNode AddFieldNode(IDataGeneratorFieldSettingsState settings)
            {
                FieldKindNode fieldsNode = GetFieldKindNode(settings.FieldKind);

                var node = new FieldNode(settings);

                fieldsNode.Nodes.Add(node);

                if (settings is DirectProductFieldSettingsState directProduct)
                {
                    node.ContextMenuStrip = AddDisposableObject(CreateDirectProductFieldNodeMenu(directProduct));
                }

                return node;
            }

            /// <summary>
            /// Removes the node associated with the specified field.
            /// </summary>
            /// <param name="settings"></param>
            /// <returns></returns>
            internal void RemoveFieldNode(IDataGeneratorFieldSettingsState settings)
            {
                if (settings is DataGeneratorFieldSettingsState singleField)
                {
                    foreach (FieldNode node in FindFieldNode(FieldNode, singleField))
                    {
                        node.Remove();
                    }
                }
                else if (settings is DataGeneratorTupleFieldSettingsState tupleField)
                {
                    foreach (FieldNode node in FindFieldNode(TupleFieldNode, tupleField))
                    {
                        node.Remove();
                    }
                }
                else if (settings is DataGeneratorAdditionalFieldSettingsState additionalField)
                {
                    foreach (FieldNode node in FindFieldNode(AdditionalFieldNode, additionalField))
                    {
                        node.Remove();
                    }
                }
                else if (settings is DataGeneratorAdditionalTupleFieldSettingsState additionalTupleField)
                {
                    foreach (FieldNode node in FindFieldNode(AdditionalTupleFieldNode, additionalTupleField))
                    {
                        node.Remove();
                    }
                }
            }

            /// <summary>
            /// Adds the node associated with the specified DirectProduct inner field.
            /// </summary>
            /// <param name="settings"></param>
            /// <returns></returns>
            internal FieldNode? AddDirectProductInnerFieldNode(DirectProductInnerFieldSettingsState settings)
            {
                foreach (FieldNode node in TupleFieldNode.FieldNodes)
                {
                    if (node.FieldSettings == settings.Owner)
                    {
                        var innerNode = new FieldNode(settings);

                        node.Nodes.Add(innerNode);

                        return innerNode;
                    }
                }

                return null;
            }

            /// <summary>
            /// Removes the node associated with the specified DirectProduct inner field.
            /// </summary>
            /// <param name="settings"></param>
            /// <returns></returns>
            internal void RemoveDirectProductInnerFieldNode(DirectProductInnerFieldSettingsState settings)
            {
                foreach (FieldNode node in TupleFieldNode.FieldNodes)
                {
                    if (node.FieldSettings == settings.Owner)
                    {
                        foreach (FieldNode innerNode in node.FieldNodes)
                        {
                            if (innerNode.FieldSettings == settings)
                            {
                                innerNode.Remove();
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Updates the state of the node associated with the specified field settings.
            /// </summary>
            /// <param name="settings"></param>
            internal void RefreshFieldNode(IDataGeneratorFieldSettingsState settings)
            {
                if (settings is DataGeneratorFieldSettingsState singleField)
                {
                    foreach (FieldNode node in FindFieldNode(FieldNode, singleField))
                    {
                        node.Refresh();
                    }
                }
                else if (settings is DataGeneratorTupleFieldSettingsState tupleField)
                {
                    foreach (FieldNode node in FindFieldNode(TupleFieldNode, tupleField))
                    {
                        node.Refresh();
                    }
                }
                else if (settings is DataGeneratorAdditionalFieldSettingsState additionalField)
                {
                    foreach (FieldNode node in FindFieldNode(AdditionalFieldNode, additionalField))
                    {
                        node.Refresh();
                    }
                }
                else if (settings is DataGeneratorAdditionalTupleFieldSettingsState additionalTupleField)
                {
                    foreach (FieldNode node in FindFieldNode(AdditionalTupleFieldNode, additionalTupleField))
                    {
                        node.Refresh();
                    }
                }
            }

            /// <summary>
            /// Updates the state of the node associated with the specified DirectProduct inner field settings.
            /// </summary>
            /// <param name="settings"></param>
            internal void RefreshDirectProductInnerFieldNode(DirectProductInnerFieldSettingsState settings)
            {
                foreach (FieldNode node in FindFieldNode(TupleFieldNode, settings))
                {
                    node.Refresh();
                }
            }

            /// <summary>
            /// Finds the node where the specified field is set.
            /// </summary>
            /// <param name="rootNode"></param>
            /// <param name="fieldSetting"></param>
            /// <returns></returns>
            IEnumerable<FieldNode> FindFieldNode(TreeNode rootNode, IDataGeneratorFieldSettingsState fieldSetting)
            {
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node is FieldNode fieldNode && fieldNode.FieldSettings == fieldSetting)
                    {
                        yield return fieldNode;
                    }

                    foreach (var childNode in FindFieldNode(node, fieldSetting))
                    {
                        yield return childNode;
                    }
                }
            }

            #region menu handler

            /// <summary>
            /// Create a context menu for the field node.
            /// </summary>
            /// <returns></returns>
            private ContextMenuStrip CreateFieldNodeMenu()
            {
                var menu = new ContextMenuStrip();

                menu.Items.Add("New Field", GetAddIcon(), (sender, e) =>
                {
                    m_Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.StartEdit, new DataGeneratorFieldSettingsState());
                }
                );

                return menu;
            }

            /// <summary>
            /// Create a context menu for the directProduct field node.
            /// </summary>
            /// <param name="directProduct"></param>
            /// <returns></returns>
            private ContextMenuStrip CreateDirectProductFieldNodeMenu(DirectProductFieldSettingsState directProduct)
            {
                var menu = new ContextMenuStrip();

                menu.Items.Add("New Field", GetAddIcon(), (sender, e) =>
                {
                    m_Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.StartEdit, new DirectProductInnerFieldSettingsState(directProduct));
                }
                );

                return menu;
            }

            /// <summary>
            /// Create a context menu for the tuple field node.
            /// </summary>
            /// <returns></returns>
            private ContextMenuStrip CreateTupleFieldNodeMenu()
            {
                var menu = new ContextMenuStrip();

                menu.Items.Add("New TupleField", GetAddIcon(), (sender, e) =>
                {
                    m_Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.StartEdit, new DataGeneratorTupleFieldSettingsState());
                }
                );

                menu.Items.Add("New DuplexProductField", GetAddIcon(), (sender, e) =>
                {
                    if (GetSenderNode(sender) is not TreeNode senderNode) { return; }

                    DirectProductFieldSettingsState directProduct = DirectProductFieldSettingsState.CreateNew();

                    m_Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.Added, directProduct);
                }
                );

                return menu;
            }

            /// <summary>
            /// Create a context menu for the additional field node.
            /// </summary>
            /// <returns></returns>
            private ContextMenuStrip CreateAdditionalFieldNodeMenu()
            {
                var menu = new ContextMenuStrip();

                menu.Items.Add("New AdditionalField", GetAddIcon(), (sender, e) =>
                {
                    m_Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.StartEdit, new DataGeneratorAdditionalFieldSettingsState());
                }
                );

                return menu;
            }

            /// <summary>
            /// Create a context menu for the additional tuple field node.
            /// </summary>
            /// <returns></returns>
            private ContextMenuStrip CreateAdditionalTupleFieldNodeMenu()
            {
                var menu = new ContextMenuStrip();

                menu.Items.Add("New AdditionalTupleField", GetAddIcon(), (sender, e) =>
                {
                    m_Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.StartEdit, new DataGeneratorAdditionalTupleFieldSettingsState());
                }
                );

                return menu;
            }

            static Image? GetAddIcon()
            {
                return null;
                // return IconImageList.Singleton.GetImage(IconImageIndex.Add);
            }

            static TreeNode? GetSenderNode(object sender)
            {
                if (sender is not ToolStripItem menu) { return null; }
                if (menu.Owner is not ContextMenuStrip context) { return null; }
                if (context.SourceControl is not TreeView tree) { return null; }
                return tree.SelectedNode;
            }

            #endregion

        }

        /// <summary>
        /// Node representing a field kind.
        /// </summary>
        private class FieldKindNode : TreeNode
        {
            /// <summary>
            /// Create a new instance.
            /// </summary>
            /// <param name="fieldKind"></param>
            internal FieldKindNode(DataGeneratorFieldKind fieldKind)
            {
                FieldKind = fieldKind;

                Text = $"{fieldKind}";
                ImageIndex = (int)IconImageIndex.FieldGroup;
                SelectedImageIndex = ImageIndex;
            }

            /// <summary>
            /// Gets the field kind.
            /// </summary>
            internal DataGeneratorFieldKind FieldKind { get; }

            /// <summary>
            /// Enumerates the field nodes.
            /// </summary>
            internal IEnumerable<FieldNode> FieldNodes
            {
                get
                {
                    foreach (TreeNode node in Nodes)
                    {
                        if (node is FieldNode fieldNode) { yield return fieldNode; }
                    }
                }
            }
        }

        /// <summary>
        /// Node representing a field.
        /// </summary>
        private class FieldNode : TreeNode
        {
            /// <summary>
            /// Create a new instance.
            /// </summary>
            /// <param name="settings"></param>
            internal FieldNode(IDataGeneratorFieldSettingsState settings)
            {
                static int GetIconIndex(DataGeneratorFieldKind fieldKind)
                {
                    return fieldKind switch
                    {
                        DataGeneratorFieldKind.Field => (int)IconImageIndex.Field,
                        DataGeneratorFieldKind.TupleField => (int)IconImageIndex.TupleField,
                        DataGeneratorFieldKind.AdditionalField => (int)IconImageIndex.Field,
                        DataGeneratorFieldKind.AdditionalTupleField => (int)IconImageIndex.TupleField,
                        _ => -1,
                    };
                }

                FieldSettings = settings;

                Text = GetFieldNames(settings);
                ImageIndex = GetIconIndex(settings.FieldKind);
                SelectedImageIndex = ImageIndex;

                Tag = settings;
            }

            static string GetFieldNames(IDataGeneratorFieldSettingsState settings)
            {
                var names = settings?.GetFieldNames();

                if (names == null || names.Length == 0) { return DataGeneratorFieldSettingsStateBase.UndefinedFieldName; }

                return string.Join(", ", names);
            }

            /// <summary>
            /// Gets the field settings.
            /// </summary>
            internal IDataGeneratorFieldSettingsState FieldSettings { get; }

            /// <summary>
            /// Enumerates the field nodes.
            /// </summary>
            internal IEnumerable<FieldNode> FieldNodes
            {
                get
                {
                    foreach (TreeNode node in Nodes)
                    {
                        if (node is FieldNode fieldNode) { yield return fieldNode; }
                    }
                }
            }

            internal void Refresh()
            {
                Text = GetFieldNames(FieldSettings);
            }
        }

        #endregion

        #region field editor

        /// <summary>
        /// Shows the specified field settings in the editor.
        /// </summary>
        /// <param name="field"></param>
        private void ShowFieldEditor(DataGeneratorFieldSettingsState field)
        {
            if (FieldEditor is not DataGeneratorFieldEditor editor)
            {
                editor = new DataGeneratorFieldEditor(m_Context)
                {
                    Dock = DockStyle.Fill
                };
                FieldEditor = editor;
            }

            editor.SetFieldSettings(field);
        }

        /// <summary>
        /// Shows the specified tuple field settings in the editor.
        /// </summary>
        /// <param name="field"></param>
        private void ShowTupleFieldEditor(DataGeneratorTupleFieldSettingsState field)
        {
            if (FieldEditor is not DataGeneratorTupleFieldEditor editor)
            {
                editor = new DataGeneratorTupleFieldEditor(m_Context)
                {
                    Dock = DockStyle.Fill
                };
                FieldEditor = editor;
            }

            editor.SetFieldSettings(field);
        }

        /// <summary>
        /// Shows the specified DirectProduct inner field settings in the editor.
        /// </summary>
        /// <param name="field"></param>
        private void ShowDirectProductFieldEditor(DirectProductFieldSettingsState field)
        {
            if (FieldEditor is not DirectProductFieldEditor editor)
            {
                editor = new DirectProductFieldEditor(m_Context)
                {
                    Dock = DockStyle.Fill
                };
                FieldEditor = editor;
            }

            editor.SetDirectProductFieldSettings(field);
        }

        /// <summary>
        /// Shows the specified additional field settings in the editor.
        /// </summary>
        /// <param name="field"></param>
        private void ShowAdditionalFieldEditor(DataGeneratorAdditionalFieldSettingsState field)
        {
            if (FieldEditor is not DataGeneratorAdditionalFieldEditor editor)
            {
                editor = new DataGeneratorAdditionalFieldEditor(m_Context)
                {
                    Dock = DockStyle.Fill
                };
                FieldEditor = editor;
            }

            editor.SetFieldSettings(field);
        }

        /// <summary>
        /// Shows the specified additional tuple field settings in the editor.
        /// </summary>
        /// <param name="field"></param>
        private void ShowAdditionalTupleFieldEditor(DataGeneratorAdditionalTupleFieldSettingsState field)
        {
            if (FieldEditor is not DataGeneratorAdditionalTupleFieldEditor editor)
            {
                editor = new DataGeneratorAdditionalTupleFieldEditor(m_Context)
                {
                    Dock = DockStyle.Fill
                };
                FieldEditor = editor;
            }

            editor.SetFieldSettings(field);
        }

        #endregion

        #region preview

        /// <summary>
        /// Executes initial processing related to preview.
        /// </summary>
        private void InitPreview()
        {
            btnPreview.Click += (sender, e) =>
            {
                if (CurrentDataGeneratorSettings == null) { return; }

                try
                {
                    ShowPreview(CurrentDataGeneratorSettings.CreateSettingsJson(false));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }

        private void ShowPreview(string generatorSettingsJson)
        {
            m_Context.CurrentExecutor.ShowPreview(generatorSettingsJson, FormUtility.PreviewDateCount);
        }

        #endregion

        #region csv

        /// <summary>
        /// Executes initial processing related to csv output.
        /// </summary>
        private void InitOutputCsv()
        {
            btnOutputCsv.Click += (sender, e) =>
            {
                if (CurrentDataGeneratorSettings == null) { return; }

                try
                {
                    OutputCsv(CurrentDataGeneratorSettings.CreateSettingsJson(false));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }

        private void OutputCsv(string generatorSettingsJson)
        {
            m_Context.CurrentExecutor.OutputCsv(generatorSettingsJson, CurrentCsvSettings);
        }

        #endregion

        #region messaging

        private IDisposable? m_Subscriber;

        /// <summary>
        /// Executes initial processing related to messaging.
        /// </summary>
        private void InitMessaging()
        {

            var selectedField = m_Context.FieldEventSubscriber.Subscribe(DataGeneratorFieldEvent.Selected, field =>
            {
                if (field is DataGeneratorFieldSettingsState singleField)
                {
                    ShowFieldEditor(singleField);
                }
                else if (field is DirectProductFieldSettingsState directProductField)
                {
                    ShowDirectProductFieldEditor(directProductField);
                }
                else if (field is DataGeneratorTupleFieldSettingsState tupleField)
                {
                    ShowTupleFieldEditor(tupleField);
                }
                else if (field is DataGeneratorAdditionalFieldSettingsState additionalField)
                {
                    ShowAdditionalFieldEditor(additionalField);
                }
                else if (field is DataGeneratorAdditionalTupleFieldSettingsState additionalTupleField)
                {
                    ShowAdditionalTupleFieldEditor(additionalTupleField);
                }
                else
                {
                    FieldEditor = null;
                }
            });

            var startEdit = m_Context.FieldEventSubscriber.Subscribe(DataGeneratorFieldEvent.StartEdit, field =>
            {
                if (field is DataGeneratorFieldSettingsState singleField)
                {
                    ShowFieldEditor(singleField);
                }
                else if (field is DirectProductFieldSettingsState directProductField)
                {
                    ShowDirectProductFieldEditor(directProductField);
                }
                else if (field is DataGeneratorTupleFieldSettingsState tupleField)
                {
                    ShowTupleFieldEditor(tupleField);
                }
                else if (field is DataGeneratorAdditionalFieldSettingsState additionalField)
                {
                    ShowAdditionalFieldEditor(additionalField);
                }
                else if (field is DataGeneratorAdditionalTupleFieldSettingsState additionalTupleField)
                {
                    ShowAdditionalTupleFieldEditor(additionalTupleField);
                }
                else
                {
                    FieldEditor = null;
                }
            });

            var addedField = m_Context.FieldEventSubscriber.Subscribe(DataGeneratorFieldEvent.Added, field =>
            {
                if (CurrentDataGeneratorSettings == null) { return; }
                if (field == null) { return; }

                if (field is DirectProductInnerFieldSettingsState innerField)
                {
                    innerField.ApplyToOwner();

                    m_FieldTree.RefreshFieldNode(innerField.Owner);

                    var node = m_FieldTree.AddDirectProductInnerFieldNode(innerField);

                    if (node != null)
                    {
                        treeFields.SelectedNode = node;
                        node.EnsureVisible();
                    }
                }
                else
                {
                    CurrentDataGeneratorSettings.AddField(field);

                    var node = m_FieldTree.AddFieldNode(field);

                    if (node != null)
                    {
                        treeFields.SelectedNode = node;
                        node.EnsureVisible();
                    }
                }
            });

            var updatedField = m_Context.FieldEventSubscriber.Subscribe(DataGeneratorFieldEvent.Updated, field =>
            {
                if (CurrentDataGeneratorSettings == null) { return; }
                if (field == null) { return; }

                if (field is DirectProductInnerFieldSettingsState innerField)
                {
                    innerField.ApplyToOwner();

                    m_FieldTree.RefreshFieldNode(innerField.Owner);

                    m_FieldTree.RefreshDirectProductInnerFieldNode(innerField);
                }

                m_FieldTree.RefreshFieldNode(field);
            });

            var removedField = m_Context.FieldEventSubscriber.Subscribe(DataGeneratorFieldEvent.Removed, field =>
            {
                if (CurrentDataGeneratorSettings == null) { return; }
                if (field == null) { return; }

                if (field is DirectProductInnerFieldSettingsState innerField)
                {
                    innerField.RemoveFromOwner();

                    m_FieldTree.RemoveDirectProductInnerFieldNode(innerField);

                    m_FieldTree.RefreshFieldNode(innerField.Owner);
                }
                else
                {
                    CurrentDataGeneratorSettings.RemoveField(field);

                    m_FieldTree.RemoveFieldNode(field);
                }
            });

            m_Subscriber = DisposableBag.Create(selectedField, startEdit, addedField, updatedField, removedField);


            this.Disposed += (sender, e) =>
            {
                m_Subscriber?.Dispose();
            };

        }

        #endregion

    }

}

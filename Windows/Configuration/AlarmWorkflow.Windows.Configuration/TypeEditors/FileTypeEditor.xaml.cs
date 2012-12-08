﻿using System.Windows.Controls;
using AlarmWorkflow.Shared.Core;
using AlarmWorkflow.Windows.ConfigurationContracts;

namespace AlarmWorkflow.Windows.Configuration.TypeEditors
{
    /// <summary>
    /// Interaction logic for FileTypeEditor.xaml
    /// </summary>
    [Export("FileTypeEditor", typeof(ITypeEditor))]
    public partial class FileTypeEditor : UserControl, ITypeEditor
    {
        #region Fields

        private string _filterString;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileTypeEditor"/> class.
        /// </summary>
        public FileTypeEditor()
        {
            InitializeComponent();

            _filterString = "Alle Dateien (*.*)|*.*";
        }

        #endregion

        #region Event handlers

        private void Browse_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.CheckFileExists = false;
            ofd.Filter = _filterString;
            if (this.Value != null)
            {
                ofd.FileName = (string)this.Value;
            }
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Value = ofd.FileName;
            }
        }

        #endregion

        #region ITypeEditor Members

        /// <summary>
        /// Gets/sets the value that is edited.
        /// </summary>
        public object Value
        {
            get { return txtValue.Text; }
            set { txtValue.Text = (string)value; }
        }

        /// <summary>
        /// Gets the visual element that is editing the value.
        /// </summary>
        public System.Windows.UIElement Visual
        {
            get { return this; }
        }

        void ITypeEditor.Initialize(string editorParameter)
        {
            if (string.IsNullOrWhiteSpace(editorParameter))
            {
                return;
            }

            _filterString = editorParameter;
        }

        #endregion
    }
}

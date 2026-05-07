using System.Collections.Generic;
using System.Windows;

namespace TestWPFSample
{
    public partial class ControlsDemoWindow : Window
    {
        public ControlsDemoWindow()
        {
            InitializeComponent();

            DemoDataGrid.ItemsSource = new List<object>
            {
                new { Name = "ListView", Type = "Selection" },
                new { Name = "TreeView", Type = "Hierarchy" },
                new { Name = "DataGrid", Type = "Table" }
            };
        }
    }
}
namespace FileRenamer.Models
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using FileRenamer.ViewModels;
    using Microsoft.Xaml.Behaviors;

    public class DropBehavior : Behavior<ListView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            // ファイルをドラッグしてきて、コントロール上に乗せた際の処理
            AssociatedObject.PreviewDragOver += AssociatedObject_PreviewDragOver;

            // ファイルをドロップした際の処理
            AssociatedObject.Drop += AssociatedObject_Drop;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewDragOver -= AssociatedObject_PreviewDragOver;
            AssociatedObject.Drop -= AssociatedObject_Drop;
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            var vm = ((ListView)sender).DataContext as MainWindowViewModel;
            vm.FileList = MakeFileSystemInfoList(files);
        }

        private void AssociatedObject_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
        }

        private List<ExFileSystemInfo> MakeFileSystemInfoList(string[] uris)
        {
            List<ExFileSystemInfo> fileList;
            fileList = new List<ExFileSystemInfo>();

            foreach (string uriString in uris)
            {
                fileList.Add(new ExFileSystemInfo(uriString));
            }

            return fileList;
        }
    }
}

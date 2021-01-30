using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FileRenamer.ViewModels;
using Microsoft.Xaml.Behaviors;

namespace FileRenamer.Models {
    class DropBehavior : Behavior<ListView>{

        protected override void OnAttached() {
            base.OnAttached();

            // ファイルをドラッグしてきて、コントロール上に乗せた際の処理
            this.AssociatedObject.PreviewDragOver += AssociatedObject_PreviewDragOver;

            // ファイルをドロップした際の処理
            this.AssociatedObject.Drop += AssociatedObject_Drop;
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            var vm = ((ListView)sender).DataContext as MainWindowViewModel;
            vm.FileList = makeFileSystemInfoList(files);
        }

        private void AssociatedObject_PreviewDragOver(object sender, DragEventArgs e) {
            e.Effects = DragDropEffects.Copy;
            e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
        }

        protected override void OnDetaching() {
            base.OnDetaching();
            this.AssociatedObject.PreviewDragOver -= AssociatedObject_PreviewDragOver;
            this.AssociatedObject.Drop -= AssociatedObject_Drop;
        }

        private List<FileSystemInfo> makeFileSystemInfoList(string[] uris) {

            List<FileSystemInfo> fileList;
            fileList = new List<FileSystemInfo>();

            foreach(string uriString in uris) {
                fileList.Add(new ExFileSystemInfo(uriString));
            }

            return fileList;
        }
    }
}

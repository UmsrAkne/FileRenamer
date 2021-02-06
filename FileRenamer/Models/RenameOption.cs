using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Models {
    public class RenameOption : BindableBase{

        public string AttachmentString {
            get => attachmentString; set => SetProperty(ref attachmentString, value);
        }

        private string attachmentString = "";


        public int InsertIndex {
            get => insertIndex; set => SetProperty(ref insertIndex, value);
        }

        private int insertIndex = 0;


        public int Digits {
            get => digits; set => SetProperty(ref digits, value);
        }

        private int digits = 1;


        public int StartCount {
            get => startCount; set => SetProperty(ref startCount, value);
        }

        private int startCount = 0;

    }
}

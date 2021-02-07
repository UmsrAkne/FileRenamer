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


        public int NumberInsertIndex {
            get => numberInsertIndex; set => SetProperty(ref numberInsertIndex, value);
        }

        private int numberInsertIndex = 0;

        public int StringInsertIndex {
            get => stringInsertIndex; set => SetProperty(ref stringInsertIndex, value);
        }

        private int stringInsertIndex;


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

namespace FileRenamer.Models
{
    using Prism.Mvvm;

    public class RenameOption : BindableBase
    {
        private string attachmentString = string.Empty;
        private int numberInsertIndex = 0;
        private int stringInsertIndex;
        private int digits = 1;
        private int startCount = 0;

        public string AttachmentString
        {
            get => attachmentString; set => SetProperty(ref attachmentString, value);
        }

        public int NumberInsertIndex
        {
            get => numberInsertIndex; set => SetProperty(ref numberInsertIndex, value);
        }

        public int StringInsertIndex
        {
            get => stringInsertIndex; set => SetProperty(ref stringInsertIndex, value);
        }

        public int Digits
        {
            get => digits; set => SetProperty(ref digits, value);
        }

        public int StartCount
        {
            get => startCount; set => SetProperty(ref startCount, value);
        }
    }
}

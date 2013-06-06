namespace DocumentSystem
{
    public abstract class EncryptableDocument : BinaryDocument, IEncryptable
    {
        private bool isEncrypted;

        public bool IsEncrypted
        {
            get { return this.isEncrypted; }
            protected set { this.isEncrypted = value; }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }

        public override string ToString()
        {
            if (!this.isEncrypted)
            {
                return base.ToString();
            }
            return this.GetType().Name + "[encrypted]";
        }
    }
}

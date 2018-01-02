using System;

namespace Domain.Entities
{
    public class ExternalLogin
    {
        #region Scalar Properties

        public int ExternalLoginId { get; set; }
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual int UserId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual User User { get; set; }
        #endregion
    }
}

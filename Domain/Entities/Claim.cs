﻿using System;

namespace Domain.Entities
{
    public class Claim
    {
      
        #region Scalar Properties
        public virtual int ClaimId { get; set; }
        public virtual int UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
        #endregion

        #region Navigation Properties
        public virtual User User { get; set; }
        #endregion
    }
}

using ProTecht.Enum;
using ProTecht.People;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace ProTecht.Quotes
{
    public abstract class QuoteBase : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? Amount { get; set; }

        public virtual Vendor Vendor { get; set; }
        public Guid? PersonId { get; set; }

        protected QuoteBase()
        {

        }

        public QuoteBase(Guid id, Guid? personId, Vendor vendor, string? amount = null)
        {

            Id = id;
            Vendor = vendor;
            Amount = amount;
            PersonId = personId;
        }

    }
}
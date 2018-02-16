using Evol.Logging.AdapteNLog.FxTests;
using System.Data.Entity.ModelConfiguration;

namespace Evol.Logging.AdapteNLog.FxTests.Map
{
    public class OperateLogMap : EntityTypeConfiguration<OperateLog>
    {
        public OperateLogMap()
        {
            ToTable("OperateLog");
            HasKey(e => e.Id);
            Property(e => e.Ip).IsRequired().HasMaxLength(100);
            Property(e => e.OperatorId).IsRequired().HasMaxLength(50);
            Property(e => e.OperAccount).IsRequired().HasMaxLength(100);
            Property(e => e.OperBranch).IsRequired().HasMaxLength(100);
            Property(e => e.OperType).IsRequired();
            Ignore(e => e.OperTypeIntVal);
            Property(e => e.OperRemark).IsRequired();
            Property(e => e.MemberId).IsOptional().HasMaxLength(50);
            Property(e => e.OriginalValue).IsRequired().HasMaxLength(5000);
            Property(e => e.ModifiedValue).IsRequired().HasMaxLength(5000);
            Property(e => e.ModelType).IsRequired().HasMaxLength(200);
            Property(e => e.Action).IsRequired();
            Property(e => e.SubAction).IsRequired();
            Ignore(e => e.ActionIntVal);
            Ignore(e => e.SubActionIntVal);
            Property(e => e.Business).IsOptional().HasMaxLength(200);
            Property(e => e.Remark).IsOptional().HasMaxLength(500);
            Property(e => e.CreateTime).IsRequired();
        }
    }
}


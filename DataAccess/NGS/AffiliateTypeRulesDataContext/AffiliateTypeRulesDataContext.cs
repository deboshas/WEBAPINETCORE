using DataContext.Extension;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NGS.DataContext
{
    public partial class NGSDataContext
    {
        public async Task<IEnumerable<NGS_GetAffiliateTypeRule_Result>> NGS_GetAffiliateTypeRuleAsync(int? ruleMatrixId, int? affiliateTypeId, string affiliateTypeCode = null, int? ruleType = null)
        {
            return await this.LoadStoredProc(GetProcedureName<NGS_GetAffiliateTypeRule_Result>())
                .WithSqlParam("@RuleMatrixId", (dbParam) => dbParam.Value = ruleMatrixId)
                .WithSqlParam("@AffiliateTypeId", (dbParam) => dbParam.Value = affiliateTypeId)
                .WithSqlParam("@AffiliateTypeCode", (dbParam) => dbParam.Value = affiliateTypeCode)
                .WithSqlParam("@RuleType", (dbParam) => dbParam.Value = ruleType)
                .ExecuteStoredProcAsync<NGS_GetAffiliateTypeRule_Result>().ConfigureAwait(false);
        }

        public async Task<string> NGS_SaveAffiliateTypeAsync(int? affiliateTypeId, string affiliateTypeCode, string affiliateTypeName, bool? isaffiliateActive, bool? isaffiliateInProduction, bool? isaffiliateInWIP, int? displayOrder, int? rank, int? createdBy, int? modifiedBy, bool? canGenerateConflicts, string affiliateTypeAliasCode, int? organizationType, string displayCode, string hexColorCode, string addAttributeCategoryComment, string description, string longDescription, Guid? auditId, short? actionId = null)
        {
            SqlParameter isSuccessfulParam = null;
            SqlParameter errorCodeParam = null;
            SqlParameter transactionIdParameter = null;

            await this.LoadStoredProc("dbo.NGS_SaveAffiliateType")
                .WithSqlParam("@AffiliateTypeId", (dbParam) => dbParam.Value = affiliateTypeId)
                .WithSqlParam("@AffiliateTypeCode", (dbParam) => dbParam.Value = affiliateTypeCode)
                .WithSqlParam("@AffiliateTypeName", (dbParam) => dbParam.Value = affiliateTypeName)
                .WithSqlParam("@IsActive", (dbParam) => dbParam.Value = isaffiliateActive)
                .WithSqlParam("@InProduction", (dbParam) => dbParam.Value = isaffiliateInProduction)
                .WithSqlParam("@InWIP", (dbParam) => dbParam.Value = isaffiliateInWIP)
                .WithSqlParam("@DisplayOrder", (dbParam) => dbParam.Value = displayOrder)
                .WithSqlParam("@Rank", (dbParam) => dbParam.Value = rank)
                .WithSqlParam("@CreatedBy", (dbParam) => dbParam.Value = createdBy)
                .WithSqlParam("@ModifiedBy", (dbParam) => dbParam.Value = modifiedBy)
                .WithSqlParam("@CanGenerateConflicts", (dbParam) => dbParam.Value = canGenerateConflicts)
                .WithSqlParam("@AffiliateTypeAliasCode", (dbParam) => dbParam.Value = affiliateTypeAliasCode)
                .WithSqlParam("@OrganizationType", (dbParam) => dbParam.Value = organizationType)
                .WithSqlParam("@DisplayCode", (dbParam) => dbParam.Value = displayCode)
                .WithSqlParam("@HexColorCode", (dbParam) => dbParam.Value = hexColorCode)
                .WithSqlParam("@Description", (dbParam) => dbParam.Value = description)
                .WithSqlParam("@LongDescription", (dbParam) => dbParam.Value = longDescription)
                .WithSqlParam("@SaveAffiliateTypeComment", (dbParam) => dbParam.Value = addAttributeCategoryComment)
                .WithSqlParam("@AuditId", (dbParam) => dbParam.Value = auditId)
                .WithSqlParam("@ActionId", (dbParam) => dbParam.Value = actionId)
                .WithSqlParam("@IsSuccessful", (dbParam) =>
                {
                    dbParam.Direction = ParameterDirection.Output;
                    dbParam.SqlDbType = SqlDbType.Bit;
                    dbParam.Value = DBNull.Value;
                    isSuccessfulParam = dbParam;
                })
                .WithSqlParam("@ErrorCode", (dbParam) =>
                {
                    dbParam.Direction = ParameterDirection.Output;
                    dbParam.SqlDbType = SqlDbType.NVarChar;
                    dbParam.Value = DBNull.Value;
                    dbParam.Size = 100;
                    errorCodeParam = dbParam;
                })
                .WithSqlParam("@TransactionId", (dbParam) =>
                {
                    dbParam.Direction = ParameterDirection.Output;
                    dbParam.SqlDbType = SqlDbType.BigInt;
                    dbParam.Value = DBNull.Value;
                    transactionIdParameter = dbParam;
                })
                .ExecuteStoredProcAsync<string>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }

        public async Task<IEnumerable<NGS_GetAffiliateGroupsByAffiliateType_Result>> NGS_GetAffiliateGroupsByAffiliateTypeAsync(int? affiliateTypeId)
        {
            return await this.LoadStoredProc(GetProcedureName<NGS_GetAffiliateGroupsByAffiliateType_Result>())
                .WithSqlParam("@AffiliateTypeId", (dbParam) => dbParam.Value = affiliateTypeId)
                .ExecuteStoredProcAsync<NGS_GetAffiliateGroupsByAffiliateType_Result>().ConfigureAwait(false);
        }

        public async Task<IEnumerable<int>> NGS_SaveAffiliateTypeRuleAsync(int? affiliateTypeId, int? userId, IEnumerable<SqlDataRecord> tblTreeRules)
        {
            return await this.LoadStoredProc("NGS_SaveAffiliateTypeRule")
                .WithSqlParam("@AffiliateTypeId", (dbParam) => dbParam.Value = affiliateTypeId)
                .WithSqlParam("@UserId", (dbParam) => dbParam.Value = userId)
                .WithSqlParam("@TreeRules", (dbParam) =>
                {
                    dbParam.SqlDbType = SqlDbType.Structured;
                    dbParam.TypeName = "dbo.utt_NGSTreeRules";
                    dbParam.Value = tblTreeRules;
                })
                .ExecuteStoredProcAsync<int>().ConfigureAwait(false);
        }
    }
}
using DataContext.Extension;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGS.DataContext
{
    public partial class NGSDataContext
    {
        public async Task<IEnumerable<NGS_GetSLPDashboardCount_Result>> NGS_GetSLPDashboardCountAsync(int? slpUserId, int? slpSLADays, int? slpAutoApprovedDays)
        {
            return await this.LoadStoredProc(GetProcedureName<NGS_GetSLPDashboardCount_Result>())
                .WithSqlParam("@SLPUserId", (dbParam) =>
                {
                    dbParam.Value = slpUserId;
                })
                .WithSqlParam("@SLPSLADays", (dbParam) =>
                {
                    dbParam.Value = slpSLADays;
                })
                .WithSqlParam("@SLPAutoApprovedDays", (dbParam) =>
                {
                    dbParam.Value = slpAutoApprovedDays;
                })
                .ExecuteStoredProcAsync<NGS_GetSLPDashboardCount_Result>().ConfigureAwait(false);
        }

        public async Task<IEnumerable<NGS_GetSLPDashboardRequests_Result>> NGS_GetSLPDashboardRequestsAsync(int? userId, string status, string sstatus, string rstatus, System.DateTime? submitFrom, System.DateTime? submitTo, System.DateTime? overdueTo, string dateType, int? requestID, string san, int? client, string archive, string function, string wonLost, int? epcountryID, string entityName, string pcaobCode, int? epentityID, int? epuserID, int? serviceID, string viewAboutExpired, string serviceCodes, string entityType, string skcName, int? reqUserID, int? entityID, string duns, int? pageNumber, int? pageSize, string sortCriteria, string sortDirection)
        {
            return await this.LoadStoredProc(GetProcedureName<NGS_GetSLPDashboardRequests_Result>())
                .WithSqlParam("@UserId", (dbParam) =>
                {
                    dbParam.Value = userId;
                })
                .WithSqlParam("@Status", (dbParam) =>
                {
                    dbParam.Value = status;
                })
                .WithSqlParam("@SStatus", (dbParam) =>
                {
                    dbParam.Value = sstatus;
                })
                .WithSqlParam("@RStatus", (dbParam) =>
                {
                    dbParam.Value = rstatus;
                })
                .WithSqlParam("@SubmitFrom", (dbParam) =>
                {
                    dbParam.Value = submitFrom;
                })
                .WithSqlParam("@SubmitTo", (dbParam) =>
                {
                    dbParam.Value = submitTo;
                })
                .WithSqlParam("@OverdueTo", (dbParam) =>
                {
                    dbParam.Value = overdueTo;
                })
                .WithSqlParam("@DateType", (dbParam) =>
                {
                    dbParam.Value = dateType;
                })
                .WithSqlParam("@RequestID", (dbParam) =>
                {
                    dbParam.Value = requestID;
                })
                .WithSqlParam("@SAN", (dbParam) =>
                {
                    dbParam.Value = san;
                })
                .WithSqlParam("@Client", (dbParam) =>
                {
                    dbParam.Value = client;
                })
                .WithSqlParam("@Archive", (dbParam) =>
                {
                    dbParam.Value = archive;
                })
                .WithSqlParam("@Function", (dbParam) =>
                {
                    dbParam.Value = function;
                })
                .WithSqlParam("@WonLost", (dbParam) =>
                {
                    dbParam.Value = wonLost;
                })
                .WithSqlParam("@EPCountryID", (dbParam) =>
                {
                    dbParam.Value = epcountryID;
                })
                .WithSqlParam("@EntityName", (dbParam) =>
                {
                    dbParam.Value = entityName;
                })
                .WithSqlParam("@PCAOBCode", (dbParam) =>
                {
                    dbParam.Value = pcaobCode;
                })
                .WithSqlParam("@EPEntityID", (dbParam) =>
                {
                    dbParam.Value = epentityID;
                })
                .WithSqlParam("@EPUserID", (dbParam) =>
                {
                    dbParam.Value = epuserID;
                })
                .WithSqlParam("@ServiceID", (dbParam) =>
                {
                    dbParam.Value = serviceID;
                })
                .WithSqlParam("@ViewAboutExpired", (dbParam) =>
                {
                    dbParam.Value = viewAboutExpired;
                })
                .WithSqlParam("@ServiceCodes", (dbParam) =>
                {
                    dbParam.Value = serviceCodes;
                })
                .WithSqlParam("@EntityType", (dbParam) =>
                {
                    dbParam.Value = entityType;
                })
                .WithSqlParam("@SKCName", (dbParam) =>
                {
                    dbParam.Value = skcName;
                })
                .WithSqlParam("@ReqUserID", (dbParam) =>
                {
                    dbParam.Value = reqUserID;
                })
                .WithSqlParam("@EntityID", (dbParam) =>
                {
                    dbParam.Value = entityID;
                })
                .WithSqlParam("@DUNS", (dbParam) =>
                {
                    dbParam.Value = duns;
                })
                .WithSqlParam("@PageNumber", (dbParam) =>
                {
                    dbParam.Value = pageNumber;
                })
                .WithSqlParam("@PageSize", (dbParam) =>
                {
                    dbParam.Value = pageSize;
                })
                .WithSqlParam("@SortCriteria", (dbParam) =>
                {
                    dbParam.Value = sortCriteria;
                })
                .WithSqlParam("@SortDirection", (dbParam) =>
                {
                    dbParam.Value = sortDirection;
                })                
                .ExecuteStoredProcAsync<NGS_GetSLPDashboardRequests_Result>().ConfigureAwait(false);
        }
    }
}

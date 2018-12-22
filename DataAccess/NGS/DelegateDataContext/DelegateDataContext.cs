using DataContext.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NGS.DataContext
{
    public partial class NGSDataContext
    {
        public async Task<string> NGS_AddTreeMasterDelegateAsync(int? userId, int? gupId, bool? isactive, bool? editTree, bool? receiveEmail)
        {
            SqlParameter isSuccessfulParam = null;
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_ManageTreeMasterDelegate")
                       .WithSqlParam("@UserId", (dbParam) =>
                       {
                           dbParam.Value = userId;
                       })
                       .WithSqlParam("@GupId", (dbParam) =>
                       {
                           dbParam.Value = gupId;
                       })
                       .WithSqlParam("@IsActive", (dbParam) =>
                       {
                           dbParam.Value = isactive;
                       })
                       .WithSqlParam("@EditTree", (dbParam) =>
                       {
                           dbParam.Value = editTree;
                       })
                       .WithSqlParam("@ReceiveEmail", (dbParam) =>
                       {
                           dbParam.Value = receiveEmail;
                       })

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
                       .ExecuteStoredProcAsync<string>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }

        public async Task<string> NGS_RemoveTreeMasterDelegateAsync(int? userId, int? gupId)
        {
            SqlParameter isSuccessfulParam = null;
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_RemoveTreeMasterDelegate")
                       .WithSqlParam("@UserId", (dbParam) =>
                       {
                           dbParam.Value = userId;
                       })
                       .WithSqlParam("@GupId", (dbParam) =>
                       {
                           dbParam.Value = gupId;
                       })
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
                       .ExecuteStoredProcAsync<string>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }

        public async Task<string> NGS_UpdateTreeMasterDelegateAsync(int? userId, int? gupId, bool? isactive, bool? editTree, bool? receiveEmail)
        {
            SqlParameter isSuccessfulParam = null;
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_ManageTreeMasterDelegate")
                       .WithSqlParam("@UserId", (dbParam) =>
                       {
                           dbParam.Value = userId;
                       })
                       .WithSqlParam("@GupId", (dbParam) =>
                       {
                           dbParam.Value = gupId;
                       })
                       .WithSqlParam("@IsActive", (dbParam) =>
                       {
                           dbParam.Value = isactive;
                       })
                       .WithSqlParam("@EditTree", (dbParam) =>
                       {
                           dbParam.Value = editTree;
                       })
                       .WithSqlParam("@ReceiveEmail", (dbParam) =>
                       {
                           dbParam.Value = receiveEmail;
                       })
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
                       .ExecuteStoredProcAsync<string>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }

        public async Task<string> NGS_AddSLPDelegateAsync(int? keyClientId, int? slpUserId, int? gupId, int? userId, bool? isactive, bool? editRequest, bool? recieveEmail, bool? isemailedaA, bool? isserviceReporting)
        {
            SqlParameter isSuccessfulParam = null;
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_ManageSLPDelegate")
                       .WithSqlParam("@KeyClientId", (dbParam) =>
                       {
                           dbParam.Value = keyClientId;
                       })
                       .WithSqlParam("@SLPUserId", (dbParam) =>
                       {
                           dbParam.Value = slpUserId;
                       })
                       .WithSqlParam("@GupId", (dbParam) =>
                       {
                           dbParam.Value = gupId;
                       })
                       .WithSqlParam("@UserId", (dbParam) =>
                       {
                           dbParam.Value = userId;
                       })
                       .WithSqlParam("@IsActive", (dbParam) =>
                       {
                           dbParam.Value = isactive;
                       })
                       .WithSqlParam("@EditRequest", (dbParam) =>
                       {
                           dbParam.Value = editRequest;
                       })
                       .WithSqlParam("@ReceiveEmail", (dbParam) =>
                       {
                           dbParam.Value = recieveEmail;
                       })
                       .WithSqlParam("@IsEmailedAA", (dbParam) =>
                       {
                           dbParam.Value = isemailedaA;
                       })
                       .WithSqlParam("@IsServiceReporting", (dbParam) =>
                       {
                           dbParam.Value = isserviceReporting;
                       })
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
                       .ExecuteStoredProcAsync<string>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }

        public async Task<string> NGS_UpdateSLPDelegateAsync(int? keyClientid, int? slpUserid, int? gupId, int? userId, bool? isactive, bool? editRequest, bool? receiveEmail, bool? isemailedAa, bool? isserviceReporting)
        {
            SqlParameter isSuccessfulParam = null;
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_ManageSLPDelegate")
                       .WithSqlParam("@KeyClientId", (dbParam) =>
                       {
                           dbParam.Value = keyClientid;
                       })
                       .WithSqlParam("@SLPUserId", (dbParam) =>
                       {
                           dbParam.Value = slpUserid;
                       })
                       .WithSqlParam("@GupId", (dbParam) =>
                       {
                           dbParam.Value = gupId;
                       })
                       .WithSqlParam("@UserId", (dbParam) =>
                       {
                           dbParam.Value = userId;
                       })
                       .WithSqlParam("@IsActive", (dbParam) =>
                       {
                           dbParam.Value = isactive;
                       })
                       .WithSqlParam("@EditRequest", (dbParam) =>
                       {
                           dbParam.Value = editRequest;
                       })
                       .WithSqlParam("@ReceiveEmail", (dbParam) =>
                       {
                           dbParam.Value = receiveEmail;
                       })
                       .WithSqlParam("@IsEmailedAA", (dbParam) =>
                       {
                           dbParam.Value = isemailedAa;
                       })
                       .WithSqlParam("@IsServiceReporting", (dbParam) =>
                       {
                           dbParam.Value = isserviceReporting;
                       })
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
                       .ExecuteStoredProcAsync<string>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }

        public async Task<string> NGS_RemoveSLPDelegateAsync(int? keyClientId, int? slpUserId, int? gupId, int? userId)
        {
            SqlParameter isSuccessfulParam = null;
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_RemoveSLPDelegate")
                       .WithSqlParam("@KeyClientId", (dbParam) =>
                       {
                           dbParam.Value = keyClientId;
                       })
                       .WithSqlParam("@SLPUserId", (dbParam) =>
                       {
                           dbParam.Value = slpUserId;
                       })
                       .WithSqlParam("@GupId", (dbParam) =>
                       {
                           dbParam.Value = gupId;
                       })
                       .WithSqlParam("@UserId", (dbParam) =>
                       {
                           dbParam.Value = userId;
                       })
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
                       .ExecuteStoredProcAsync<string>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }

        public async Task<IEnumerable<NGS_GetSLPDelegates_Result>> NGS_GetSLPDelegatesAsync(int? skcentityid = null)
        {
            return await this.LoadStoredProc(GetProcedureName<NGS_GetSLPDelegates_Result>())
                           .WithSqlParam("@SKCEntityId", (dbParam) =>
                           {
                               dbParam.Value = skcentityid;
                           })
                           .ExecuteStoredProcAsync<NGS_GetSLPDelegates_Result>().ConfigureAwait(false);
        }

        public async Task<IEnumerable<NGS_GetApprovalDelegates_Result>> NGS_GetApprovalDelegatesAsync(IEnumerable<int> approvalIds)
        {
            var approvalRecords = approvalIds.CreateSqlDataRecord();

            return await this.LoadStoredProc(GetProcedureName<NGS_GetApprovalDelegates_Result>())
                            .WithSqlParam("@ApprovalIds", (dbParam) =>
                            {
                                dbParam.SqlDbType = SqlDbType.Structured;
                                dbParam.TypeName = "dbo.utt_IntegerId";
                                dbParam.Value = approvalRecords.Any() ? approvalRecords : null;
                            })
                            .ExecuteStoredProcAsync<NGS_GetApprovalDelegates_Result>().ConfigureAwait(false);
        }
    }
}

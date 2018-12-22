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
        public async Task<IEnumerable<FTM_GetBatchFileDetails_sp_Result>> GetBatchFileDetailsAsync(DateTime startDate, DateTime endDate)
        {
            return await this.LoadStoredProc(GetProcedureName<FTM_GetBatchFileDetails_sp_Result>())
               .WithSqlParam("@startDate", (dbParam) => dbParam.Value = startDate)
               .WithSqlParam("@endDate", (dbParam) => dbParam.Value = endDate)
               .ExecuteStoredProcAsync<FTM_GetBatchFileDetails_sp_Result>().ConfigureAwait(false);
        }

        public async Task<IEnumerable<NGSFTM_GetArchivedRecordDetails_sp_Result>> GetArchivedRecordDetailsAsync(int batchId)
        {
            return await this.LoadStoredProc(GetProcedureName<NGSFTM_GetArchivedRecordDetails_sp_Result>())
             .WithSqlParam("@BatchId", (dbParam) => dbParam.Value = batchId)
             .ExecuteStoredProcAsync<NGSFTM_GetArchivedRecordDetails_sp_Result>().ConfigureAwait(false);
        }

        public async Task<string> InsertExcelDatatoDBAsync(string loggedinUser, string fileName, Guid uploadid, double fileSize, List<DataTable> dataTableList)
        {
            int totalRecCount = 0;

            foreach (DataTable row in dataTableList)
            {
                totalRecCount += row.Rows.Count;
            }

            SqlParameter batchIdSqlPara = null;
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("FTM_RecordBatchActionFile_sp")
                 .WithSqlParam("@FileName", (dbParam) => dbParam.Value = fileName)
                 .WithSqlParam("@UploadId", (dbParam) => dbParam.Value = uploadid)
                 .WithSqlParam("@FileSize", (dbParam) => dbParam.Value = fileSize)
                 .WithSqlParam("@UploadedBy", (dbParam) => dbParam.Value = loggedinUser)
                 .WithSqlParam("@RecordCount", (dbParam) => dbParam.Value = totalRecCount)
                 .WithSqlParam("@Batchid", (dbParam) =>
                 {
                     dbParam.Direction = ParameterDirection.Output;
                     dbParam.SqlDbType = SqlDbType.Int;
                     dbParam.Value = DBNull.Value;
                     batchIdSqlPara = dbParam;
                 })
                 .ExecuteStoredProcAsync<int>().ConfigureAwait(false);

            await this.LoadStoredProc("FTM_LoadActionRecordsInQueue_sp")
            .WithSqlParam("@ActionRecordsTable", (dbParam) =>
            {
                dbParam.SqlDbType = SqlDbType.Structured;
                dbParam.TypeName = "dbo.FTM_ActionQueueTableType";
                dbParam.Value = dataTableList[0];
            })
            .WithSqlParam("@ActionRecordsCtnTable", (dbParam) =>
            {
                dbParam.SqlDbType = SqlDbType.Structured;
                dbParam.TypeName = "dbo.FTM_CTN_TableType";
                dbParam.Value = dataTableList[1];
            })
            .WithSqlParam("@BatchId", (dbParam) => dbParam.Value = (int)batchIdSqlPara.Value)
            .WithSqlParam("@ErrorCode", (dbParam) =>
            {
                dbParam.Direction = ParameterDirection.Output;
                dbParam.SqlDbType = SqlDbType.NVarChar;
                dbParam.Value = DBNull.Value;
                dbParam.Size = 100;
                errorCodeParam = dbParam;
            })
            .ExecuteStoredProcAsync<int>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }

        public async Task<IEnumerable<NGS_GetAllOutageMessage_Result>> NGS_GetAllOutageMessageAsync()
        {
            return await this.LoadStoredProc(GetProcedureName<NGS_GetAllOutageMessage_Result>())
                .ExecuteStoredProcAsync<NGS_GetAllOutageMessage_Result>().ConfigureAwait(false);
        }

        public async Task<string> NGS_SaveOutageMessageAsync(string id, string body, string sub, string email, bool isActive, DateTime? effectiveDate)
        {
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_SaveOutageMessage")
                .WithSqlParam("@ID", (dbParam) => dbParam.Value = id)
                .WithSqlParam("@Body", (dbParam) => dbParam.Value = body)
                .WithSqlParam("@Subject", (dbParam) => dbParam.Value = sub)
                .WithSqlParam("@Email", (dbParam) => dbParam.Value = email)
                .WithSqlParam("@MsgActiveFlg", (dbParam) => dbParam.Value = isActive)
                .WithSqlParam("@DateEffective", (dbParam) => dbParam.Value = effectiveDate)
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

        public async Task<string> NGS_ActivateOutageMessage(string id, DateTime? effectiveDate)
        {
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_ActivateOutageMessage")
                .WithSqlParam("@ID", (dbParam) => dbParam.Value = id)
                .WithSqlParam("@DateEffective", (dbParam) => dbParam.Value = effectiveDate)
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

        public async Task<string> NGS_DeActivateOutageMessage(string id)
        {
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_DeActivateOutageMessage")
                .WithSqlParam("@ID", (dbParam) => dbParam.Value = id)
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

        public async Task<string> NGS_ManageSubServiceAsync(string actionType, string subService, string shortDesc, string longDesc, string serviceType, string pcoabCd, bool? isActiveISR, bool? requireIntegration, string modUser, bool isActive, bool? isProhibited, bool? isNBR, bool? isInternalAuditControl, bool? otherPartyRequired, string guidenceText)
        {
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_ManageSubService")
                .WithSqlParam("@ActionType", (dbParam) => dbParam.Value = actionType)
                .WithSqlParam("@SubService", (dbParam) => dbParam.Value = subService)
                .WithSqlParam("@ShortDesc", (dbParam) => dbParam.Value = shortDesc)
                .WithSqlParam("@LongDesc", (dbParam) => dbParam.Value = longDesc)
                .WithSqlParam("@ServiceType", (dbParam) => dbParam.Value = serviceType)
                .WithSqlParam("@PCAOBCd", (dbParam) => dbParam.Value = pcoabCd)
                .WithSqlParam("@IsActiveISR", (dbParam) => dbParam.Value = isActiveISR)
                .WithSqlParam("@RequireInterrogation", (dbParam) => dbParam.Value = requireIntegration)
                .WithSqlParam("@ModUser", (dbParam) => dbParam.Value = modUser)
                .WithSqlParam("@IsActive", (dbParam) => dbParam.Value = isActive)
                .WithSqlParam("@IsProhibited", (dbParam) => dbParam.Value = isProhibited)
                .WithSqlParam("@IsNBR", (dbParam) => dbParam.Value = isNBR)
                .WithSqlParam("@IsInternalAuditControl", (dbParam) => dbParam.Value = isInternalAuditControl)
                .WithSqlParam("@OtherPartyRequired", (dbParam) => dbParam.Value = otherPartyRequired)
                .WithSqlParam("@GuidenceText", (dbParam) => dbParam.Value = guidenceText)
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

        public async Task<IEnumerable<string>> GetAttributeAutoApprovedServicesAsync(short attribute)
        {
            return await this.LoadStoredProc("dbo.NGS_GetAttributeAutoApprovedServices")
             .WithSqlParam("@Attribute", (dbParam) => dbParam.Value = attribute)
             .ExecuteStoredProcAsync<string>().ConfigureAwait(false);
        }

        public async Task<string> NGS_SaveAutoApprovedServicesAsync(short attribute, IEnumerable<string> services)
        {
            SqlParameter errorCodeParam = null;

            var attributePara = services.CreateSqlDataRecord();

            await this.LoadStoredProc("NGS_SaveAutoApprovedServices")
                .WithSqlParam("@AttributeId", (dbParam) => dbParam.Value = attribute)
                .WithSqlParam("@ServiceCodes", (dbParam) =>
                {
                    dbParam.SqlDbType = SqlDbType.Structured;
                    dbParam.TypeName = "dbo.utt_VarcharCode";
                    dbParam.Value = attributePara.Any() ? attributePara : null;
                })
                .WithSqlParam("@IsSuccessful", (dbParam) =>
                {
                    dbParam.SqlDbType = SqlDbType.Bit;
                    dbParam.Value = DBNull.Value;
                    dbParam.Direction = ParameterDirection.Output;
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

        public async Task<IEnumerable<NGS_GetDnBTreeRefreshReports_Result>> NGS_GetDnBTreeRefreshReportsAsync(DateTime startDate, DateTime endDate)
        {
            return await this.LoadStoredProc(GetProcedureName<NGS_GetDnBTreeRefreshReports_Result>())
               .WithSqlParam("@ReportDateFrom", (dbParam) => dbParam.Value = startDate)
               .WithSqlParam("@ReportDateTo", (dbParam) => dbParam.Value = endDate)
               .ExecuteStoredProcAsync<NGS_GetDnBTreeRefreshReports_Result>().ConfigureAwait(false);
        }

        public async Task<string> NGS_SendTreeRefreshEmailsAsync(int reportId, int userId, bool isNotifyDelegate)
        {
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_SendTreeRefreshEmails")
                .WithSqlParam("@ReportId", (dbParam) => dbParam.Value = reportId)
                .WithSqlParam("@RequesterUserId", (dbParam) => dbParam.Value = userId)
                .WithSqlParam("@NotifyDelegate", (dbParam) => dbParam.Value = isNotifyDelegate)
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

        public async Task<IEnumerable<NGS_GetServiceToServiceConflictDetail_Result>> NGS_GetServiceToServiceConflictDetailAsync(string requestServiceType, string subServiceCode)
        {
            return await this.LoadStoredProc(GetProcedureName<NGS_GetServiceToServiceConflictDetail_Result>())
               .WithSqlParam("@RequestServiceType", (dbParam) => dbParam.Value = requestServiceType)
               .WithSqlParam("@SubServiceCode", (dbParam) => dbParam.Value = subServiceCode)
               .ExecuteStoredProcAsync<NGS_GetServiceToServiceConflictDetail_Result>().ConfigureAwait(false);
        }

        public async Task<IEnumerable<NGS_GetMailQueue_Result>> NGS_GetMailQueueAsync(IEnumerable<int> msgQueueId)
        {
            var mqidsRecords = msgQueueId.CreateSqlDataRecord();
            return await this.LoadStoredProc(GetProcedureName<NGS_GetMailQueue_Result>())
                            .WithSqlParam("@Mqids", (dbParam) =>
                            {
                                dbParam.SqlDbType = SqlDbType.Structured;
                                dbParam.TypeName = "dbo.utt_IntegerId";
                                dbParam.Value = mqidsRecords.Any() ? mqidsRecords : null;
                            })
                            .ExecuteStoredProcAsync<NGS_GetMailQueue_Result>().ConfigureAwait(false);
        }

        public async Task<(IEnumerable<NGS_SanActivatedEmailGenerate_Result>, string)> NGS_SanActivatedEmailGenerateAsync(int requestId)
        {
            SqlParameter errorCodeParam = null;

            var generatedMail = await this.LoadStoredProc(GetProcedureName<NGS_SanActivatedEmailGenerate_Result>())
                  .WithSqlParam("@RequestId", (dbParam) => dbParam.Value = requestId)
                  .WithSqlParam("@IsSuccessful", (dbParam) =>
                   {
                       dbParam.SqlDbType = SqlDbType.Bit;
                       dbParam.Value = DBNull.Value;
                       dbParam.Direction = ParameterDirection.Output;
                   })
                  .WithSqlParam("@ErrorCode", (dbParam) =>
                  {
                      dbParam.Direction = ParameterDirection.Output;
                      dbParam.SqlDbType = SqlDbType.NVarChar;
                      dbParam.Value = DBNull.Value;
                      dbParam.Size = 100;
                      errorCodeParam = dbParam;
                  })
                  .ExecuteStoredProcAsync<NGS_SanActivatedEmailGenerate_Result>().ConfigureAwait(false);

            return (generatedMail, errorCodeParam.Value.ToString());
        }

        public async Task<string> NGS_SanActivatedEmailSendAsync(string messageBody, string subjectText, string torecipient, string ccrecipient)
        {
            SqlParameter errorCodeParam = null;

            await this.LoadStoredProc("NGS_SanActivatedEmailSend")
                  .WithSqlParam("@MessageText", (dbParam) => dbParam.Value = messageBody)
                  .WithSqlParam("@SubjectText", (dbParam) => dbParam.Value = subjectText)
                  .WithSqlParam("@ToRecipient", (dbParam) => dbParam.Value = torecipient)
                  .WithSqlParam("@CCRecipient", (dbParam) => dbParam.Value = ccrecipient)
                  .WithSqlParam("@IsSuccessful", (dbParam) =>
                  {
                      dbParam.SqlDbType = SqlDbType.Bit;
                      dbParam.Value = DBNull.Value;
                      dbParam.Direction = ParameterDirection.Output;
                  })
                  .WithSqlParam("@ErrorCode", (dbParam) =>
                  {
                      dbParam.Direction = ParameterDirection.Output;
                      dbParam.SqlDbType = SqlDbType.NVarChar;
                      dbParam.Value = DBNull.Value;
                      dbParam.Size = 100;
                      errorCodeParam = dbParam;
                  })
                  .ExecuteNonQueryAsync<int>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }

        public async Task<string> NGS_UpdateServiceToServiceConflictActionAsync(Dictionary<int, string> matrix)
        {
            SqlParameter errorCodeParam = null;
            var paramMatrix = matrix.CreateSqlDataRecord();
            await this.LoadStoredProc("NGS_UpdateServiceToServiceConflictAction")
                   .WithSqlParam("@ServiceRelationList", (dbParam) =>
                   {
                       dbParam.SqlDbType = SqlDbType.Structured;
                       dbParam.TypeName = "dbo.utt_NGS_IntergerCode";
                       dbParam.Value = paramMatrix.Any() ? paramMatrix : null;
                   })
                  .WithSqlParam("@IsSuccessful", (dbParam) =>
                  {
                      dbParam.SqlDbType = SqlDbType.Bit;
                      dbParam.Value = DBNull.Value;
                      dbParam.Direction = ParameterDirection.Output;
                  })
                  .WithSqlParam("@ErrorCode", (dbParam) =>
                  {
                      dbParam.Direction = ParameterDirection.Output;
                      dbParam.SqlDbType = SqlDbType.NVarChar;
                      dbParam.Value = DBNull.Value;
                      dbParam.Size = 100;
                      errorCodeParam = dbParam;
                  })
                  .ExecuteNonQueryAsync<int>().ConfigureAwait(false);

            return Convert.ToString(errorCodeParam.Value);
        }
    }
}
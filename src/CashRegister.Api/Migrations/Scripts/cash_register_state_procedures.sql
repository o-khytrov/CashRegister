IF
EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND NAME = 'sp_cash_register_state_read')
BEGIN
DROP PROCEDURE sp_cash_register_state_read
END
GO
CREATE PROCEDURE sp_cash_register_state_read(
    @cash_register_fiscal_number bigint
)
    AS
BEGIN
SELECT
    cash_register_fiscal_number,
    shift_id,
    open_shift_fiscal_number,
    is_z_report_present,
    name,
    subject_key_id,
    fist_local_number,
    next_local_number,
    last_fiscal_number,
    is_offline_supported,
    is_chief_cashier,
    date_time,
    next_local_number_for_send,
    offline_session_id,
    offline_seed,
    offline_next_local_number,
    shift_state,
    is_testing
FROM dbo.cash_register_state
WHERE cash_register_fiscal_number = @cash_register_fiscal_number
END
GO

IF
EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND NAME = 'sp_cash_register_state_write')
BEGIN
DROP PROCEDURE sp_cash_register_state_write
END
GO
CREATE PROCEDURE sp_cash_register_state_write(
    @cash_register_fiscal_number bigint,
    @shift_state tinyint
) AS
BEGIN
INSERT INTO dbo.cash_register_state
    (cash_register_fiscal_number, date_time, shift_state)
VALUES (@cash_register_fiscal_number, GETDATE(), @shift_state)
END
GO
IF
EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND NAME = 'sp_offline_document_insert')
BEGIN
DROP PROCEDURE dbo.sp_offline_document_insert
END
GO
CREATE PROCEDURE dbo.sp_offline_document_insert @local_number bigint
    , @fiscal_number VARCHAR (32)
    , @cash_register_fiscal_number bigint
    , @offline_document_number bigint
    , @document_type SMALLINT
    , @xml nvarchar(2000)
    , @hash nvarchar(2000)
    AS
BEGIN
INSERT INTO dbo.offline_documents
(created_at,
 document_type,
 local_number,
 fiscal_number,
 offline_document_number,
 cash_register_fiscal_number,
 xml,
 hash)
VALUES (GETUTCDATE(),
        @document_type,
        @local_number,
        @fiscal_number,
        @offline_document_number,
        @cash_register_fiscal_number,
        @xml,
        @hash);

END
GO
CREATE PROCEDURE dbo.sp_offline_document_get_last @cash_register_fiscal_number bigint
    AS
BEGIN
SELECT
    TOP 1 id, created_at,
    document_type,
    local_number,
    offline_document_number,
    fiscal_number,
    cash_register_fiscal_number,
    xml,
    hash
FROM dbo.offline_documents
WHERE cash_register_fiscal_number = @cash_register_fiscal_number
ORDER BY offline_document_number DESC
END
GO
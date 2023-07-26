GO
CREATE PROCEDURE dbo.sp_document_insert @local_number bigint
    
, @fiscal_number varchar(32)
, @cash_register_id bigint
, @document_type smallint
, @xml nvarchar(max)
, @ticket nvarchar(1000)
AS
BEGIN
    insert into dbo.documents
    (created_at,
     document_type,
     local_number,
     fiscal_number,
     cash_register_id,
     xml,
     ticket)
    values (GETUTCDATE(),
            @document_type,
            @local_number,
            @fiscal_number,
            @cash_register_id,
            @xml,
            @ticket);

END

GO

CREATE PROCEDURE dbo.sp_get_last_local_number @cash_register_id bigint
AS
SELECT MAX(local_number)
FROM dbo.documents
WHERE cash_register_id = @cash_register_id
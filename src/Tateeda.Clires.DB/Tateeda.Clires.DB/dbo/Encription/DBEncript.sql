PRINT 'CREATING SECURITY OBJECTS'

IF NOT EXISTS 
    (SELECT * FROM sys.symmetric_keys WHERE symmetric_key_id = 101)
    CREATE MASTER KEY ENCRYPTION BY 
    PASSWORD = '{633B8FAC-8436-490A-826A-202050B9FF87}';

CREATE CERTIFICATE SubjectCert
   WITH SUBJECT = 'Subject Cert';

CREATE SYMMETRIC KEY SubjectKey
    WITH ALGORITHM = AES_256
    ENCRYPTION BY CERTIFICATE SubjectCert;

OPEN SYMMETRIC KEY SubjectKey
    DECRYPTION BY CERTIFICATE SubjectCert;

-- quick test
PRINT N'You should see on the next line: Encryption is working'
PRINT CONVERT(nvarchar, DecryptByKey(
			EncryptByKey(Key_GUID('SubjectKey'), N'Encryption is working')))

PRINT 'OK?'
---------------------------------------------------------------


--DECLARE @VER NVARCHAR(100)
--SELECT @VER = DbVersion FROM SchemaVersion
--PRINT 'SCHEMA VERSION: ' + @VER

USE [Tateeda.Clires.DB]
OPEN MASTER KEY DECRYPTION BY PASSWORD = '{633B8FAC-8436-490A-826A-202050B9FF87}';
BACKUP MASTER KEY TO FILE = 'C:\temp\exportedMasterKey' 
    ENCRYPTION BY PASSWORD = '{633B8FAC-8436-490A-826A-202050B9FF87}';
    
GO   
    
USE [Tateeda.Clires.DB]
RESTORE MASTER KEY 
    FROM FILE = 'C:\temp\exportedMasterKey' 
    DECRYPTION BY PASSWORD = '{633B8FAC-8436-490A-826A-202050B9FF87}' 
    ENCRYPTION BY PASSWORD = '{633B8FAC-8436-490A-826A-202050B9FF87}'
    FORCE
GO
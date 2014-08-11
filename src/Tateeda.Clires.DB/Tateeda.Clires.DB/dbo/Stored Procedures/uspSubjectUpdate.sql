
CREATE PROC [dbo].[uspSubjectUpdate] 
    @SubjectId int,
    @SiteId int,
    @Nickname nvarchar(100),
    @FamilyId nvarchar(100),
    @Notes nvarchar(1000),
    @NIMHID nvarchar(100),
    @Gender int,
    @YearBorn int,
    @Status int,
    @SortOrder int,
	@SSN nvarchar(20),
	-- cleartext
    @FirstName nvarchar(100),		-- will be encrypted
    @LastName nvarchar(100),			-- will be encrypted
    @DateOfBirth nvarchar(32)			-- will be encrypted
AS 
  BEGIN

	SET NOCOUNT ON 
	SET XACT_ABORT ON  

    DECLARE @FirstNameEnc varbinary(256),
			@LastNameEnc varbinary(256),
			@DateOfBirthEnc varbinary(256),
			@SSNEnc varbinary(256)


	-- SubjectKey must be created previously
	OPEN SYMMETRIC KEY SubjectKey
		DECRYPTION BY CERTIFICATE SubjectCert;

	SET @FirstNameEnc   = EncryptByKey(Key_GUID('SubjectKey'), @FirstName)
	SET @LastNameEnc    = EncryptByKey(Key_GUID('SubjectKey'), @LastName)
	SET @DateOfBirthEnc = EncryptByKey(Key_GUID('SubjectKey'), @DateOfBirth)
	SET @SSNEnc = EncryptByKey(Key_GUID('SubjectKey'), @SSN)

	BEGIN TRAN

		UPDATE  [dbo].[Subject]
		   SET	[SiteId] = @SiteId, 
				[Nickname] = @Nickname, 
				[FamilyId] = @FamilyId, 
				[Notes] = @Notes, 
				[NIMHID] = @NIMHID, 
				[GenderTypeId] = @Gender, 
				[YearBorn] = @YearBorn, 
				[Status] = @Status, 
				[SortOrder] = @SortOrder, 
				[FirstNameEnc] = @FirstNameEnc, 
				[LastNameEnc] = @LastNameEnc, 
				[DateOfBirthEnc] = @DateOfBirthEnc, 
				[UpdatedOn] = GETUTCDATE(),
				[SSNEnc] = @SSNEnc
		WHERE   [Id] = @SubjectId
	
	COMMIT TRAN

	SELECT @SubjectId
 END

/* Unit test

EXEC	[dbo].[uspSubjectUpdate]
		@SubjectId = 2010,
		@SiteId = 1,
		@Nickname = N'ivo',
		@FamilyId = NULL,
		@Notes = NULL,
		@NIMHID = NULL,
		@Gender = N'M',
		@YearBorn = 1992,
		@Status = 1,
		@SortOrder = 1,
		@FirstName = N'Victor',
		@LastName = N'Stoyanoff',
		@DateOfBirth = N'19920716',

EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@LastName = N'Stoy'
 */


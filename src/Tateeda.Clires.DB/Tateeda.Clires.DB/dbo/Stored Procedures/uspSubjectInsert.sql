
CREATE PROC [dbo].[uspSubjectInsert] 
    @SiteId int,
	@StudyId int,
    @Nickname nvarchar(100),
    @FamilyId nvarchar(100),
    @Notes nvarchar(1000),
    @NIMHID nvarchar(100),
    @Gender INT,
    @YearBorn int,
    @Status int,
    @SortOrder int,
	@SSN varchar(20),					-- will be encrypted
	-- cleartext
    @FirstName nvarchar(100),			-- will be encrypted
    @LastName nvarchar(100),			-- will be encrypted
    @DateOfBirth nvarchar(32),			-- will be encrypted
	@ContactTypeId int,
	@Street Nvarchar(250),
	@City nvarchar(100),
	@Zip nvarchar(50),
	@StateId int,
	@CountryId int,
	@CountryCode nvarchar(20),
	@AddressTypeId int,
	@AreaCode int,
	@PhoneNumber int,
	@Telephone nvarchar(50),
	@PhoneTypeId int,
	@EmailAddress nvarchar(200),
	@CreatedBy nvarchar(200)
AS 
  BEGIN
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

    DECLARE @FirstNameEnc varbinary(256),
			@LastNameEnc varbinary(256),
			@DateOfBirthEnc varbinary(256),
			@ContactId int,
			@PhoneId int,
			@AddressId int,
			@EmailId int,
			@SSNEnc varbinary(500)

	-- SubjectKey must be created previously
	OPEN SYMMETRIC KEY SubjectKey
		DECRYPTION BY CERTIFICATE SubjectCert;

	SET @FirstNameEnc   = EncryptByKey(Key_GUID('SubjectKey'), @FirstName)
	SET @LastNameEnc    = EncryptByKey(Key_GUID('SubjectKey'), @LastName)
	SET @DateOfBirthEnc = EncryptByKey(Key_GUID('SubjectKey'), @DateOfBirth)
	SET @SSNEnc			= EncryptByKey(Key_GUID('SubjectKey'), @SSN)
	
	BEGIN TRAN

		INSERT INTO [dbo].[Contact]
		(		
			ContactTypeId,
			IsActive,
			CreatedBy,
			CreatedOn
		)
		SELECT 
			@ContactTypeId,
			1,
			@CreatedBy,
			GETUTCDATE()
		
		SELECT @ContactId = SCOPE_IDENTITY()

		IF @PhoneNumber > 0 OR LEN(@Telephone)>0
		BEGIN
			INSERT INTO [Phone]
				(					
					AreaCode,
					CountryCode,
					Number,
					PhoneTypeId,
					Telephone,
					Status,
					IsActive,
					CreatedBy,
					CreatedOn								
				)
				SELECT
					@AreaCode,
					@CountryCode,
					@PhoneNumber,
					@PhoneTypeId,
					@Telephone,
					1,
					1,
					@CreatedBy,
					GETUTCDATE()

			SELECT @PhoneId = SCOPE_IDENTITY()

			INSERT INTO [ContactPhone]
					(
						ContactId,
						PhoneId
					)
				SELECT
					@ContactId,
					@PhoneId					
		END

		IF LEN(@Street)>0 OR LEN(@City)>0 OR LEN(@Zip)>0 OR @StateId>0 OR @CountryId>0
		BEGIN
			INSERT INTO [Address]
					(
						AddressTypeId,
						Street,
						City,
						PostalCode,
						StateId,
						CountryId,
						IsActive,
						Status,
						CreatedBy,
						CreatedOn
					)
					SELECT
						@AddressTypeId,
						@Street,
						@City,
						@Zip,
						@StateId,
						@CountryId,
						1,
						1,
						@CreatedBy,
						GETUTCDATE()

			SELECT @AddressId = SCOPE_IDENTITY()

			INSERT INTO [ContactAddress]
					(
						AddressId,
						ContactId
					)
					SELECT
						@AddressId,
						@ContactId
		END 

		IF LEN(@EmailAddress)>0
		BEGIN
			INSERT INTO Email
				(
					Address,
					IsActive,
					Status,
					CreatedBy,
					CreatedOn
				)
				SELECT
					@EmailAddress,
					1,
					1,
					@CreatedBy,
					GETUTCDATE()

			SELECT @EmailId = SCOPE_IDENTITY()

			INSERT INTO [ContactEmail]
					(
						ContactId,
						EmailId
					)
					SELECT
						@ContactId,
						@EmailId					
		END

	   INSERT INTO [dbo].[Subject] 
			(
				[ContactId],
				[SiteId], 
				[StudyId],  
				[Nickname], 
				[FamilyId], 
				[Notes], 
				[NIMHID], 
				[GenderTypeId], 
				[YearBorn], 
				[Status], 
				[SortOrder], 
				[FirstNameEnc], 
				[LastNameEnc], 
				[DateOfBirthEnc], 
				[CreatedBy],
				[CreatedOn],
				[SSNEnc]
			)

			SELECT	
				@ContactId,
				@SiteId, 
				@StudyId,  
				@Nickname, 
				@FamilyId, 
				@Notes, 
				@NIMHID, 
				@Gender, 
				@YearBorn, 
				@Status, 
				@SortOrder, 
				@FirstNameEnc, 
				@LastNameEnc, 
				@DateOfBirthEnc, 
				@CreatedBy,
				GETUTCDATE(),
				@SSNEnc
	COMMIT
	SELECT SCOPE_IDENTITY()
 END

/* Unit test

EXEC	[dbo].[uspSubjectInsert]
		@SiteId = 1,
		@Nickname = N'ivo',
		@FamilyId = NULL,
		@Notes = NULL,
		@NIMHID = NULL,
		@Gender = N'M',
		@YearBorn = 1970,
		@Status = 1,
		@SortOrder = 1,
		@FirstName = N'Ivo',
		@LastName = N'Stoyanov',
		@DateOfBirth = N'19701231'

SELECT * FROM dbo.Subject
 */


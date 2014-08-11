
CREATE PROC [dbo].[uspSubjectFindByFirstLastName] 
    @SiteId int,
	@StudyId int,
    @FirstName nvarchar(100) = NULL,
    @LastName nvarchar(100) = NULL
AS 
	BEGIN
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	-- SubjectKey must be created previously
	OPEN SYMMETRIC KEY SubjectKey
		DECRYPTION BY CERTIFICATE SubjectCert;
	
	SELECT
	s.[Id] as [SubjectId], 
	[SiteId], 
	[StudyId], 
	[Directions],
	[Nickname], 
	[FamilyId], 
	[Notes], 
	[NIMHID], 
	[GenderTypeId], 
	[YearBorn], 
	s.[Status], 
	s.[IsActive],
	s.[SortOrder],
	CONVERT(nvarchar, DecryptByKey(FirstNameEnc)) AS [FirstName],	
	CONVERT(nvarchar, DecryptByKey(LastNameEnc))  AS [LastName],
	CONVERT(nvarchar, DecryptByKey(DateOfBirthEnc)) AS [DateOfBirth],
	CONVERT(nvarchar, DecryptByKey(SSNEnc)) AS [SSN],
	NULL AS [FirstNameEnc],		-- no need for encrypted values
	NULL AS [LastNameEnc], 
	NULL AS [DateOfBirthEnc], 
	NULL AS [SSNEnc],
	s.[CreatedOn], 
	s.[UpdatedOn],
	s.[CreatedBy],
	s.[UpdatedBy],
	a.Street,
	a.City,
	a.PostalCode,
	a.StateId,
	a.CountryId,
	a.AddressTypeId,
	p.CountryCode,
	p.AreaCode,
	p.Number,
	p.Telephone,
	p.PhoneTypeId,
	pt.Name as [PhoneType],
	e.[Address] as Email,
	st.Name as [StateName],
	st.Abbr as [StateAbbr],
	country.Name as CountryName

	FROM   [dbo].[Subject] s
	JOIN Contact c on c.Id = s.ContactId
	LEFT JOIN ContactAddress ca on ca.ContactId = c.Id
	LEFT JOIN [Address] a on a.Id = ca.AddressId
	LEFT JOIN ContactPhone cp on cp.ContactId = c.Id
	LEFT JOIN Phone p on p.Id = cp.PhoneId
	LEFT JOIN PhoneType pt on pt.Id = p.PhoneTypeId
	LEFT JOIN ContactEmail ce on ce.ContactId = c.Id
	LEFT JOIN Email e on e.Id = ce.EmailId
	LEFT JOIN [State] st on st.Id = a.StateId
	LEFT JOIN Country country on country.Id = a.CountryId
	WHERE  (CONVERT(nvarchar, DecryptByKey(FirstNameEnc)) LIKE @FirstName + '%' OR @FirstName IS NULL) 
			AND
		   (CONVERT(nvarchar, DecryptByKey(LastNameEnc)) LIKE @LastName + '%' OR @LastName IS NULL) 
		   AND StudyId = @StudyId
		   AND SiteId = @SiteId
	ORDER BY FirstName, LastName

	COMMIT
	END

/* Unit test

EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@FirstName = N'Ivo',
		@LastName = N'Stoyanov'

EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@FirstName = N'Ivo'

-- test partial match
EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@FirstName = N'I'

EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@LastName = N'Stoy'

 */


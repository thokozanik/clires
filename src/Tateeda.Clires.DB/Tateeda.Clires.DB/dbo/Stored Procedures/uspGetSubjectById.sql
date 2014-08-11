
CREATE PROC [dbo].[uspGetSubjectById] 
    @SubjectId int
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
	
	WHERE  s.Id = @SubjectId
	ORDER BY FirstName, LastName

	COMMIT
	END


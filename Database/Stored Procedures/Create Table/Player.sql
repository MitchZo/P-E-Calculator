CREATE TABLE [dbo].[Player]
(
	[PlayerId]			INT				NOT NULL PRIMARY KEY, 
    [PlayerName]		NVARCHAR(128)	NULL, 
    [Slug]				NVARCHAR(128)	NULL,
	[Position]			NVARCHAR(8)		NULL,
	[PositionID]		INT				NULL,
	[Team]				NVARCHAR(16)	NULL,
	[Rookie]			BIT				NULL,
	[Age]				INT				NULL,
	[HeightFeet]		INT				NULL,
	[HeightInches]		INT				NULL,
	[Weight]			INT				NULL,
	[SeasonsExperience]	INT				NULL,
	[PickRound]			INT				NULL,
	[PickNum]			INT				NULL,
	[IsFeatured]		BIT				NULL,
	[OneQbValuesId]		INT				NOT NULL,
	[SuperflexValuesId]	INT				NOT NULL,
	[Number]			INT				NULL,
	[TeamLongName]		NVARCHAR(64)	NULL,
	[Birthday]			INT				NULL,
	[DraftYear]			INT				NULL,
	[College]			NVARCHAR(32)	NULL,
	[ByeWeek]			INT				NULL
	FOREIGN KEY (OneQbValuesId)		REFERENCES OneQbValues(OneQbValuesId)
	FOREIGN KEY (SuperflexValuesId)		REFERENCES SuperFlexValues(SuperFlexValuesId)
)
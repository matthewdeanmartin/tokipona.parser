CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [RawText] NVARCHAR(MAX) NULL, 
    [ColorizedHtml] NVARCHAR(MAX) NULL, 
    [PlaintextDiagram] NVARCHAR(MAX) NULL, 
    [Gloss] NVARCHAR(MAX) NULL, 
    [GlossLanguage] NVARCHAR(10) NULL, 
    [Language] NVARCHAR(10) NULL, 
    [LanguageVersion] NVARCHAR(10) NULL, 
    [SyntaxStrictness] NVARCHAR(10) NULL, 
    [TextType] NVARCHAR(50) NULL, 
    [DraftStatus] NVARCHAR(50) NULL, 
    [Visibility] NVARCHAR(50) NULL, 
    [Expiration] DATETIME NULL, 
    [Url] NVARCHAR(4000) NULL, 
    [AllowComments] NVARCHAR(10) NULL, 
    [AllowCommentsBy] NVARCHAR(250) NULL
)

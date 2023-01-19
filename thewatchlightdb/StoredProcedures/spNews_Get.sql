CREATE PROCEDURE [dbo].[spNews_Get]
	@Id int
AS
begin
	select Id, City, State, Latitude, Longitude, Blurb
	from dbo.[User]
	where Id = @Id;
end
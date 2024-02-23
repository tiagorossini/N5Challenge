use N5Challenge

IF NOT EXISTS(SELECT 1 FROM PermissionTypes WHERE Description = 'Administrator')
BEGIN
	
	INSERT INTO PermissionTypes VALUES ('Administrator')

END
GO

IF NOT EXISTS(SELECT 1 FROM PermissionTypes WHERE Description = 'Moderator')
BEGIN
	
	INSERT INTO PermissionTypes VALUES ('Moderator')

END
GO

IF NOT EXISTS(SELECT 1 FROM PermissionTypes WHERE Description = 'None')
BEGIN
	
	INSERT INTO PermissionTypes VALUES ('None')

END
GO
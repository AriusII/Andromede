CREATE
OR ALTER PROCEDURE
[Users].sp_Get_Users_By_Id
    @UsersId INT
AS
BEGIN
    SET
NOCOUNT ON;

SELECT UsersId,
       UsersGuid,
       Username
FROM
    [Users].Users
WHERE
    UsersId = @UsersId;
END;
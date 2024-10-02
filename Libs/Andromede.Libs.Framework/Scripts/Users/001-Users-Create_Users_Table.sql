CREATE TABLE [Users].Users
(
    UsersId   INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    UsersGuid UNIQUEIDENTIFIER               NOT NULL DEFAULT NEWSEQUENTIALID(),
    Username  VARCHAR(100)                   NOT NULL,
    Password  VARCHAR(255)                   NOT NULL,
    Email     VARCHAR(255)                   NOT NULL
)
    WITH (DATA_COMPRESSION = ROW);
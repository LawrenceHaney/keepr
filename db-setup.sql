-- CREATE TABLE profiles(
--   id VARCHAR(225) NOT NULL,
--   name VARCHAR(225) NOT NULL,
--   email VARCHAR(225) NOT NULL,
--   picture VARCHAR(225) NOT NULL,
--   PRIMARY KEY(email)
-- )


-- CREATE TABLE Keeps(
--   id int AUTO_INCREMENT,
--   creatorId VARCHAR(225) NOT NULL,
--   name VARCHAR(225) NOT NULL,
--   description VARCHAR(225),
--   img VARCHAR(225),
--   views INT,
--   shares INT,
--   keeps INT,
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE Vaults(
--   id int AUTO_INCREMENT,
--   creatorId VARCHAR(225) NOT NULL,
--   name VARCHAR(225) NOT NULL,
--   description VARCHAR(225),
--   IsPrivate TINYINT,
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE VaultKeeps(
--   id int AUTO_INCREMENT,
--   creatorId VARCHAR(225) NOT NULL,
--   VaultId VARCHAR(225) NOT NULL,
--   KeepId VARCHAR(225),
--   PRIMARY KEY (id)
-- )
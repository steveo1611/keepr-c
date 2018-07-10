
-- made change: changed id type from int to varchar
-- CREATE TABLE users (
--     id VARCHAR(100) NOT NULL, 
--     username VARCHAR(20) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     password VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );

-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId int,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId int,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId int NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (vaultId, keepId),
--     INDEX (userId),

--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = 2)

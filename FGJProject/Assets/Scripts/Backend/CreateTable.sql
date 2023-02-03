-- Drop DB (if needed)
DROP DATABASE HIGHSCORES;

SHOW DATABASES;

-- Create DB 
CREATE DATABASE IF NOT EXISTS HIGHSCORES;

-- Set default DB and show it's tables
USE HIGHSCORES;
SHOW TABLES;

-- Drop table (if neede)
DROP TABLE HIGHSCORES;

-- Create table for highscores
CREATE TABLE IF NOT EXISTS HIGHSCORES (
    id INT AUTO_INCREMENT PRIMARY KEY,
    playername VARCHAR(255),
    score DECIMAL(7,2),
    playtime DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Check create stms 
DESCRIBE HIGHSCORES;

-- Insert some test data into table
INSERT INTO HIGHSCORES (playername, score) VALUES ("Olli K", "50");
INSERT INTO HIGHSCORES (playername, score) VALUES ("Henkka K", "150");
INSERT INTO HIGHSCORES (playername, score) VALUES ("Ismo J", "70");
INSERT INTO HIGHSCORES (playername, score) VALUES ("Matti W", "90");

-- Test the stmts needed in the bakcend here
SELECT * FROM HIGHSCORES ORDER BY score;

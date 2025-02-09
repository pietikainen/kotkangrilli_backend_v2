------------------------------------------------------------------------
-- Kotkangrilli database schema v2
-- Date: 2025-02-08
--
------------------------------------------------------------------------
-- Start by dropping and deleting all tables, triggers and functions
------------------------------------------------------------------------

-- Drop all tables if they exist
DROP TABLE IF EXISTS users, user_level;

-- Delete functions and their triggers if they exist
DROP FUNCTION IF EXISTS update_updated_at_column CASCADE;

------------------------------------------------------------------------
-- Begin creating tables, triggers and functions
------------------------------------------------------------------------
-- Create function to update updated_at column
CREATE OR REPLACE FUNCTION update_updated_at_column()
RETURNS TRIGGER AS $$
BEGIN
    NEW.updated_at = CURRENT_TIMESTAMP;
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Create user level table
CREATE TABLE user_level (
                            id SERIAL PRIMARY KEY,
                            role VARCHAR(50) NOT NULL UNIQUE,
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create trigger to update updated_at column in userlevel
CREATE TRIGGER update_user_level_updated_at
    BEFORE UPDATE ON user_level
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_at_column();

-- Create users table
CREATE TABLE users (
                       id SERIAL PRIMARY KEY,
                       snowflake BIGINT NOT NULL UNIQUE,
                       username VARCHAR(50) NOT NULL,
                       nickname VARCHAR(50),
                       avatar VARCHAR(255),
                       email VARCHAR(50) NOT NULL UNIQUE,
                       phone VARCHAR(50) UNIQUE,
                       iban VARCHAR(50) UNIQUE,
                       user_level_id INT REFERENCES user_level(id) ON DELETE SET NULL,
                       created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                       updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                       last_login TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create trigger to update updated_at column in users
CREATE TRIGGER update_users_updated_at
    BEFORE UPDATE ON users
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_at_column();

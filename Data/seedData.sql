-- Kotkangrilli database schema v2
-- Seed data for database testing

-- Insert seed data for userroles
INSERT INTO user_level (role) VALUES
                                   ('disabled'),
                                   ('user'),
                                   ('organizer'),
                                    ('admin')
    ON CONFLICT (role) DO NOTHING;
-- Insert seed data for users

INSERT INTO users (snowflake, username, nickname, avatar, email, phone, iban, user_level_id)
VALUES
    (12345678, 'matti', 'Masa', 'a1b2c3d4.png', 'matti@example.com', '0401234567', 'FI12 3456 7890 1234', 1),
    (87654321, 'tiina', 'Tinke', 'e5f6g7h8.png', 'tiina@example.com', '0509876543', 'FI98 7654 3210 9876',2),
    (23456789, 'erkki', 'Eki', 'i9j0k1l2.png', 'erkki@example.com', '0451122334', 'FI34 5678 9012 3456', 3),
    (98765432, 'johanna', 'Hanna', 'm3n4o5p6.png', 'johanna@example.com', '0412233445', 'FI56 7890 1234 5678', 1),
    (34567890, 'pekka', 'Pexi', 'q7r8s9t0.png', 'pekka@example.com', '0445566778', 'FI78 9012 3456 7890', 1)
    ON CONFLICT (snowflake) DO NOTHING;


-- Example update to seed data
UPDATE users SET nickname = 'Masanaattori' WHERE snowflake = 12345678;
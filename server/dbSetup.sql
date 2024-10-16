CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) UNIQUE COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE houses (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    sqft INT NOT NULL,
    bedrooms INT NOT NULL,
    bathrooms DOUBLE NOT NULL,
    imgUrl VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    price INT NOT NULL,
    location ENUM(
        'Urban',
        'Rural',
        'Metropolitan',
        'Wilderness',
        'unknown'
    ) default "unknown" NOT NULL,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    creatorId VARCHAR(255) NOT NULL,
    Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

Drop Table houses;

INSERT INTO
    houses (
        sqft,
        bedrooms,
        bathrooms,
        imgUrl,
        description,
        price,
        location,
        creatorId
    )
Values (
        '20000',
        '3',
        '2',
        'https://images.unsplash.com/photo-1535989983313-dc5d0d9d1d4f?q=80&w=1885&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
        'Nice House in the Woods great for vacations',
        1000000,
        'Wilderness',
        '66e04bf70483818f681bcaa1'
    )
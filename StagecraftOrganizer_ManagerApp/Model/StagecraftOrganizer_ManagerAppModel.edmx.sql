
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/09/2017 14:01:20
-- Generated from EDMX file: C:\Users\Udeshi\Documents\Visual Studio 2015\Projects\StagecraftOrganizer_ManagerApp\StagecraftOrganizer_ManagerApp\Model\StagecraftOrganizer_ManagerAppModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StagecraftOrganizerCentralDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookingTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_BookingTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketTypeTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TicketTypeTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketSeat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TicketSeat];
GO
IF OBJECT_ID(N'[dbo].[FK_UserBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_UserBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_BlockBlockRow]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlockRows] DROP CONSTRAINT [FK_BlockBlockRow];
GO
IF OBJECT_ID(N'[dbo].[FK_BlockRowSeat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Seats] DROP CONSTRAINT [FK_BlockRowSeat];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BlockRows]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlockRows];
GO
IF OBJECT_ID(N'[dbo].[Blocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blocks];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Seats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Seats];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[TicketTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketTypes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BlockRows'
CREATE TABLE [dbo].[BlockRows] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RowNo] int  NOT NULL,
    [RowLetter] nvarchar(4)  NOT NULL,
    [Block_BlockNo] int  NOT NULL
);
GO

-- Creating table 'Blocks'
CREATE TABLE [dbo].[Blocks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BlockNo] int  NOT NULL,
    [Direction] nvarchar(100)  NOT NULL,
    [Floor] nvarchar(100)  NOT NULL,
    [TheatreBlockNo] nvarchar(10)  NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BookingId] int  NOT NULL,
    [BookingDate] datetime  NOT NULL,
    [User_UserId] int  NOT NULL
);
GO

-- Creating table 'Seats'
CREATE TABLE [dbo].[Seats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SeatNo] int  NOT NULL,
    [BlockRow_RowNo] int  NOT NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TicketNo] int  NOT NULL,
    [TicketType_TicketTypeId] int  NOT NULL,
    [Booking_BookingId] int  NULL,
    [ReservationStatus] nvarchar(max)  NOT NULL,
    [Seat_SeatNo] int  NOT NULL
);
GO

-- Creating table 'TicketTypes'
CREATE TABLE [dbo].[TicketTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TicketTypeId] int  NOT NULL,
    [TypeName] nvarchar(20)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [Password] nvarchar(150)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RowNo] in table 'BlockRows'
ALTER TABLE [dbo].[BlockRows]
ADD CONSTRAINT [PK_BlockRows]
    PRIMARY KEY CLUSTERED ([RowNo] ASC);
GO

-- Creating primary key on [BlockNo] in table 'Blocks'
ALTER TABLE [dbo].[Blocks]
ADD CONSTRAINT [PK_Blocks]
    PRIMARY KEY CLUSTERED ([BlockNo] ASC);
GO

-- Creating primary key on [BookingId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([BookingId] ASC);
GO

-- Creating primary key on [SeatNo] in table 'Seats'
ALTER TABLE [dbo].[Seats]
ADD CONSTRAINT [PK_Seats]
    PRIMARY KEY CLUSTERED ([SeatNo] ASC);
GO

-- Creating primary key on [TicketNo] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([TicketNo] ASC);
GO

-- Creating primary key on [TicketTypeId] in table 'TicketTypes'
ALTER TABLE [dbo].[TicketTypes]
ADD CONSTRAINT [PK_TicketTypes]
    PRIMARY KEY CLUSTERED ([TicketTypeId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Booking_BookingId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_BookingTicket]
    FOREIGN KEY ([Booking_BookingId])
    REFERENCES [dbo].[Bookings]
        ([BookingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingTicket'
CREATE INDEX [IX_FK_BookingTicket]
ON [dbo].[Tickets]
    ([Booking_BookingId]);
GO

-- Creating foreign key on [TicketType_TicketTypeId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TicketTypeTicket]
    FOREIGN KEY ([TicketType_TicketTypeId])
    REFERENCES [dbo].[TicketTypes]
        ([TicketTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketTypeTicket'
CREATE INDEX [IX_FK_TicketTypeTicket]
ON [dbo].[Tickets]
    ([TicketType_TicketTypeId]);
GO

-- Creating foreign key on [Seat_SeatNo] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TicketSeat]
    FOREIGN KEY ([Seat_SeatNo])
    REFERENCES [dbo].[Seats]
        ([SeatNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketSeat'
CREATE INDEX [IX_FK_TicketSeat]
ON [dbo].[Tickets]
    ([Seat_SeatNo]);
GO

-- Creating foreign key on [User_UserId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_UserBooking]
    FOREIGN KEY ([User_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBooking'
CREATE INDEX [IX_FK_UserBooking]
ON [dbo].[Bookings]
    ([User_UserId]);
GO

-- Creating foreign key on [Block_BlockNo] in table 'BlockRows'
ALTER TABLE [dbo].[BlockRows]
ADD CONSTRAINT [FK_BlockBlockRow]
    FOREIGN KEY ([Block_BlockNo])
    REFERENCES [dbo].[Blocks]
        ([BlockNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlockBlockRow'
CREATE INDEX [IX_FK_BlockBlockRow]
ON [dbo].[BlockRows]
    ([Block_BlockNo]);
GO

-- Creating foreign key on [BlockRow_RowNo] in table 'Seats'
ALTER TABLE [dbo].[Seats]
ADD CONSTRAINT [FK_BlockRowSeat]
    FOREIGN KEY ([BlockRow_RowNo])
    REFERENCES [dbo].[BlockRows]
        ([RowNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlockRowSeat'
CREATE INDEX [IX_FK_BlockRowSeat]
ON [dbo].[Seats]
    ([BlockRow_RowNo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
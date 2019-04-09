-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 02 Apr 2019 pada 11.50
-- Versi Server: 10.1.26-MariaDB
-- PHP Version: 7.1.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_ujikom`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `motor`
--

CREATE TABLE `motor` (
  `kd_motor` varchar(10) NOT NULL,
  `type` varchar(20) DEFAULT NULL,
  `merk` varchar(30) DEFAULT NULL,
  `harga` int(11) NOT NULL,
  `picture` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `motor`
--

INSERT INTO `motor` (`kd_motor`, `type`, `merk`, `harga`, `picture`) VALUES
('MTR00001', 'MIO Z', 'Mio', 1000000, 'Yamaha_Mio_L_1.jpg');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pelanggan`
--

CREATE TABLE `pelanggan` (
  `kd_pelanggan` int(11) NOT NULL,
  `nama_pelanggan` char(50) DEFAULT NULL,
  `no_ktp` int(20) NOT NULL,
  `alamat` varchar(100) DEFAULT NULL,
  `pekerjaan` char(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `pelanggan`
--

INSERT INTO `pelanggan` (`kd_pelanggan`, `nama_pelanggan`, `no_ktp`, `alamat`, `pekerjaan`) VALUES
(3, 'Aini', 12345, 'Jl. Golf', 'Siswa');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pembayaran_cicilan`
--

CREATE TABLE `pembayaran_cicilan` (
  `no_bayar` varchar(10) NOT NULL,
  `tgl_bayar` datetime(6) NOT NULL,
  `bulan_bayar` int(2) NOT NULL,
  `nominal_bayar` int(11) NOT NULL,
  `sisa_cicilan` int(11) NOT NULL,
  `status_bayar` int(1) NOT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `no_kredit` varchar(10) DEFAULT NULL,
  `denda` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `petugas`
--

CREATE TABLE `petugas` (
  `kd_petugas` int(11) NOT NULL,
  `nama` char(50) DEFAULT NULL,
  `bagian` varchar(50) DEFAULT NULL,
  `keterangan` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `petugas`
--

INSERT INTO `petugas` (`kd_petugas`, `nama`, `bagian`, `keterangan`) VALUES
(1, 'admin', 'admin', 'admin'),
(4, 'Yogi', 'Admin Kedua', 'Admin Kedua'),
(6, 'Chandra', 'Kasir', 'Kasir'),
(7, 'Torik Al', 'CSO', 'CSO'),
(8, 'Yandi Saefulloh', 'Sales', 'Sales');

-- --------------------------------------------------------

--
-- Struktur dari tabel `roleclaims`
--

CREATE TABLE `roleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `roles`
--

CREATE TABLE `roles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  `Discriminator` longtext NOT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `roles`
--

INSERT INTO `roles` (`Id`, `Name`, `ConcurrencyStamp`, `Discriminator`, `NormalizedName`) VALUES
('6638d67f-6a9c-4775-a95c-efedb749e354', 'kasir', '806102a1-ced4-4a56-9de3-c3cdd5891d3b', 'IdentityRole', 'KASIR'),
('854be0fc-d369-4efb-a9d8-329fbdf13383', 'admin', '4a8ffb4c-be3e-436f-ae15-62d521a9c13e', 'IdentityRole', 'ADMIN'),
('9a1fce3a-be2a-4483-9331-08fc1c711354', 'sales', '0a2a75fd-5f87-47fc-bb36-cb561c37201f', 'IdentityRole', 'SALES'),
('d432630d-a3b6-4afa-98d9-6fc28aea4a7f', 'cso', 'b2033586-b477-4ac4-bb9e-94c9a16e0f48', 'IdentityRole', 'CSO');

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi_kredit`
--

CREATE TABLE `transaksi_kredit` (
  `no_kredit` varchar(10) NOT NULL,
  `kd_motor` varchar(10) DEFAULT NULL,
  `kd_pelanggan` int(11) NOT NULL,
  `dp` int(11) NOT NULL,
  `tenor` int(11) NOT NULL,
  `bunga` int(11) NOT NULL,
  `cicilan` int(11) NOT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `status_verif` int(1) NOT NULL,
  `tgl_verif` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `Discriminator` longtext NOT NULL,
  `kd_petugas` int(11) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL DEFAULT b'0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`Id`, `UserName`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `Discriminator`, `kd_petugas`, `NormalizedUserName`, `TwoFactorEnabled`) VALUES
('0f862c7f-3108-4834-86ea-508b0020a1a7', 'csotorik', 'AQAAAAEAACcQAAAAEADldEAdBAX0l33I7WyNyLUQHI6r/+25XQ2KbVRvBDRwms214qOTpzLLFEmQ/PH0sw==', '3eb0d34f-e404-436e-aced-9409bf449f83', 'd3a8c03f-f9e2-4f7b-a1d8-772deb2e1c7c', 'ApplicationUser', 7, 'CSOTORIK', b'1111111111111111111111111111111'),
('36e5b0ed-db51-467f-80fc-d80219f8a2d3', 'salesyandi', 'AQAAAAEAACcQAAAAEH9nQHowdYRUfJF2Zq5divhlYLUwc6BdTtV/CxoycCo3gLjVRXXW2A9cQxtLfGukjA==', '90d9a6a7-ae44-4f88-9fb6-bf692e0acbfa', '7893d5df-0c4c-4b1a-898a-6b859771d904', 'ApplicationUser', 8, 'SALESYANDI', b'1111111111111111111111111111111'),
('574c1334-fa49-466c-ab2d-c3257337b661', 'kasirchand', 'AQAAAAEAACcQAAAAEDeXhwDEvfdL2qB/mcOGSGYqDhPAjElFBDw/w/bp8TmPiL4NbPPuBmqFisy+EQDO1A==', '47bb8ab3-1a63-448c-b7c1-c6af365102ce', 'a5d875ca-cb54-4b11-8e45-2968708cca38', 'ApplicationUser', 6, 'KASIRCHAND', b'1111111111111111111111111111111'),
('b1cbc5a2-c6cd-4ec2-97f0-2db7611dc906', 'adminyogi', 'AQAAAAEAACcQAAAAEAgDSHodTsff51R4kmbxYk+2FywRJ48IZqEwQLxOkGhO10PaR76qfj0cEWYdSvIp7g==', '2f843b06-0bd3-4f8f-8034-6d71120eb817', 'e4483dca-b028-46ac-bbbb-540d0c452875', 'ApplicationUser', 4, 'ADMINYOGI', b'1111111111111111111111111111111'),
('ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'admin', 'AQAAAAEAACcQAAAAEOxKf4JK8le3A+yDVUTU+T8sz63Pu4YsWSFx2kNlEfoCHEcUOcK7Uvltd/9FBK5tXg==', '49bdc816-70b1-42f5-b001-83f4813308f9', '7ec685b8-ba37-4c1f-90e4-e078814b1193', 'ApplicationUser', 1, 'ADMIN', b'1111111111111111111111111111111');

-- --------------------------------------------------------

--
-- Struktur dari tabel `userclaims`
--

CREATE TABLE `userclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `userlogins`
--

CREATE TABLE `userlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `userroles`
--

CREATE TABLE `userroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `userroles`
--

INSERT INTO `userroles` (`UserId`, `RoleId`) VALUES
('0f862c7f-3108-4834-86ea-508b0020a1a7', 'd432630d-a3b6-4afa-98d9-6fc28aea4a7f'),
('36e5b0ed-db51-467f-80fc-d80219f8a2d3', '9a1fce3a-be2a-4483-9331-08fc1c711354'),
('574c1334-fa49-466c-ab2d-c3257337b661', '6638d67f-6a9c-4775-a95c-efedb749e354'),
('b1cbc5a2-c6cd-4ec2-97f0-2db7611dc906', '854be0fc-d369-4efb-a9d8-329fbdf13383'),
('ddc47979-9616-4e7b-9ff7-ea18b8016b0b', '854be0fc-d369-4efb-a9d8-329fbdf13383');

-- --------------------------------------------------------

--
-- Struktur dari tabel `usertokens`
--

CREATE TABLE `usertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20190401072830_create first table', '2.1.0-rtm-30799'),
('20190401074920_add foreign key petugas_id', '2.1.0-rtm-30799'),
('20190401080000_add all foreign key', '2.1.0-rtm-30799'),
('20190401080635_add user foreign key', '2.1.0-rtm-30799'),
('20190401080935_add field denda', '2.1.0-rtm-30799'),
('20190401144816_remove unnecessary field', '2.1.0-rtm-30799'),
('20190401145114_remove unnecessary field 2', '2.1.0-rtm-30799'),
('20190401145256_remove unnecessary field 3', '2.1.0-rtm-30799'),
('20190401150513_remove unnecessary field 4', '2.1.0-rtm-30799'),
('20190401153736_new revert', '2.1.0-rtm-30799'),
('20190402073629_update field motor', '2.1.0-rtm-30799');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `motor`
--
ALTER TABLE `motor`
  ADD PRIMARY KEY (`kd_motor`);

--
-- Indexes for table `pelanggan`
--
ALTER TABLE `pelanggan`
  ADD PRIMARY KEY (`kd_pelanggan`);

--
-- Indexes for table `pembayaran_cicilan`
--
ALTER TABLE `pembayaran_cicilan`
  ADD PRIMARY KEY (`no_bayar`),
  ADD KEY `IX_pembayaran_cicilan_no_kredit` (`no_kredit`),
  ADD KEY `IX_pembayaran_cicilan_user_id` (`user_id`);

--
-- Indexes for table `petugas`
--
ALTER TABLE `petugas`
  ADD PRIMARY KEY (`kd_petugas`);

--
-- Indexes for table `roleclaims`
--
ALTER TABLE `roleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_RoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `transaksi_kredit`
--
ALTER TABLE `transaksi_kredit`
  ADD PRIMARY KEY (`no_kredit`),
  ADD KEY `IX_transaksi_kredit_kd_motor` (`kd_motor`),
  ADD KEY `IX_transaksi_kredit_kd_pelanggan` (`kd_pelanggan`),
  ADD KEY `IX_transaksi_kredit_user_id` (`user_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `IX_user_kd_petugas` (`kd_petugas`);

--
-- Indexes for table `userclaims`
--
ALTER TABLE `userclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_UserClaims_UserId` (`UserId`);

--
-- Indexes for table `userlogins`
--
ALTER TABLE `userlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_UserLogins_UserId` (`UserId`);

--
-- Indexes for table `userroles`
--
ALTER TABLE `userroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_UserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `usertokens`
--
ALTER TABLE `usertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pelanggan`
--
ALTER TABLE `pelanggan`
  MODIFY `kd_pelanggan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `petugas`
--
ALTER TABLE `petugas`
  MODIFY `kd_petugas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `roleclaims`
--
ALTER TABLE `roleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `userclaims`
--
ALTER TABLE `userclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `pembayaran_cicilan`
--
ALTER TABLE `pembayaran_cicilan`
  ADD CONSTRAINT `FK_pembayaran_cicilan_transaksi_kredit_no_kredit` FOREIGN KEY (`no_kredit`) REFERENCES `transaksi_kredit` (`no_kredit`) ON DELETE NO ACTION,
  ADD CONSTRAINT `FK_pembayaran_cicilan_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`Id`) ON DELETE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `roleclaims`
--
ALTER TABLE `roleclaims`
  ADD CONSTRAINT `FK_RoleClaims_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `transaksi_kredit`
--
ALTER TABLE `transaksi_kredit`
  ADD CONSTRAINT `FK_transaksi_kredit_motor_kd_motor` FOREIGN KEY (`kd_motor`) REFERENCES `motor` (`kd_motor`) ON DELETE NO ACTION,
  ADD CONSTRAINT `FK_transaksi_kredit_pelanggan_kd_pelanggan` FOREIGN KEY (`kd_pelanggan`) REFERENCES `pelanggan` (`kd_pelanggan`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_transaksi_kredit_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`Id`) ON DELETE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `FK_user_petugas_kd_petugas` FOREIGN KEY (`kd_petugas`) REFERENCES `petugas` (`kd_petugas`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `userclaims`
--
ALTER TABLE `userclaims`
  ADD CONSTRAINT `FK_UserClaims_user_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `userlogins`
--
ALTER TABLE `userlogins`
  ADD CONSTRAINT `FK_UserLogins_user_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `userroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `FK_UserRoles_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_UserRoles_user_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `usertokens`
--
ALTER TABLE `usertokens`
  ADD CONSTRAINT `FK_UserTokens_user_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

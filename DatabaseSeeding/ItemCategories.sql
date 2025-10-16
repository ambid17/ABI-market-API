truncate "ItemCategories" CASCADE; -- Clears the table and any dependent data
ALTER SEQUENCE "ItemCategories_Id_seq" RESTART WITH 1; -- Resets the primary key sequence

insert into "ItemCategories"("Name")
values
('Equipment'),
('Weapon Accessories'),
('Weapon Bolts'),
('Ammo'),
('Medical Supplies'),
('Tactical Items'),
('Keys'),
('Miscellaneous'),
('Provisions');

select * from "ItemCategories";

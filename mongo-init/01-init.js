const dbName = "game_store";

db = db.getSiblingDB(dbName);

// Create the game_items collection
db.createCollection("game_items");

// Insert sample data into the game_items collection
db.game_items.insertMany([
    { _id: UUID(), Name: "Iron Sword", Rarity: "Common", Damage: 15, AttackSpeed: new Decimal128("1.5"), PurchasePrice: 100, SellPrice: 25 },
    { _id: UUID(), Name: "Wolf Fang Dagger", Rarity: "Uncommon", Damage: 10, AttackSpeed: new Decimal128("2.5"), PurchasePrice: 250, SellPrice: 60 },
    { _id: UUID(), Name: "Elven Bow", Rarity: "Rare", Damage: 20, AttackSpeed: new Decimal128("1.2"), PurchasePrice: 500, SellPrice: 120 },
    { _id: UUID(), Name: "Dragon Slayer Axe", Rarity: "Epic", Damage: 35, AttackSpeed: new Decimal128("0.8"), PurchasePrice: 1200, SellPrice: 300 },
    { _id: UUID(), Name: "Staff of the Magi", Rarity: "Legendary", Damage: 50, AttackSpeed: new Decimal128("1.0"), PurchasePrice: 2500, SellPrice: 650 },
    { _id: UUID(), Name: "Dragon Dagger", Rarity: "Mythic", Damage: 60, AttackSpeed: new Decimal128("2.0"), PurchasePrice: 5000, SellPrice: 1500 }
]);

// Create the shops collection
db.createCollection("shops");

// Insert sample data into the shops collection
db.shops.insertMany([
    { _id: UUID(), Name: "Westgate Armory", Location: "Capital City - West Gate"},
    { _id: UUID(), Name: "Elven Treasures", Location: "Elven Forest - Hidden Glade" },
    { _id: UUID(), Name: "Dwarven Forge", Location: "Mountain Stronghold - Ironclad Hall" },
    { _id: UUID(), Name: "Mystic Emporium", Location: "Mage's Quarter - Arcane Alley" },
    { _id: UUID(), Name: "Dragon's Hoard", Location: "Dragon's Lair - Treasure Vault" }
]);

// Create the inventories collection
db.createCollection("inventories");

// Insert sample data into the inventories collection
db.inventories.insertMany([
    { _id:UUID(), ShopId: db.shops.findOne({ Name: "Westgate Armory" })._id, ItemId: db.game_items.findOne({ Name: "Iron Sword" })._id, Quantity: 50 },
    { _id:UUID(), ShopId: db.shops.findOne({ Name: "Westgate Armory" })._id, ItemId: db.game_items.findOne({ Name: "Wolf Fang Dagger" })._id, Quantity: 30 },
    { _id:UUID(), ShopId: db.shops.findOne({ Name: "Elven Treasures" })._id, ItemId: db.game_items.findOne({ Name: "Elven Bow" })._id, Quantity: 20 },
    { _id:UUID(), ShopId: db.shops.findOne({ Name: "Dwarven Forge" })._id, ItemId: db.game_items.findOne({ Name: "Dragon Slayer Axe" })._id, Quantity: 10 },
    { _id:UUID(), ShopId: db.shops.findOne({ Name: "Mystic Emporium" })._id, ItemId: db.game_items.findOne({ Name: "Staff of the Magi" })._id, Quantity: 5 },
    { _id:UUID(), ShopId: db.shops.findOne({ Name: "Dragon's Hoard" })._id, ItemId: db.game_items.findOne({ Name: "Dragon Dagger" })._id, Quantity: 2 }
]);


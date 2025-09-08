// MongoDB Playground
// Use Ctrl+Space inside a snippet or a string literal to trigger completions.

// The current database to use.

// add sample data into game_items collection
use("GameStore");

db.game_items.insertMany([
    {_id: UUID(), Name: "Wolf Fang Mace", Rarity: "0", Damage: 55, AttackSpeed: 2.0, PurchasePrice: 350, SellPrice: 100},
    {_id: UUID(), Name: "Dragon Slayer", Rarity: "5", Damage: 120, AttackSpeed: 1.2, PurchasePrice: 1200, SellPrice: 300},
    {_id: UUID(), Name: "Elven Bow", Rarity: "3", Damage: 75, AttackSpeed: 1.8, PurchasePrice: 600, SellPrice: 150},
    {_id: UUID(), Name: "Shadow Dagger", Rarity: "4", Damage: 90, AttackSpeed: 2.5, PurchasePrice: 800, SellPrice: 200},
    {_id: UUID(), Name: "Staff of Wisdom", Rarity: "2", Damage: 40, AttackSpeed: 1.0, PurchasePrice: 400, SellPrice: 100}
])

db.game_items.find().pretty()


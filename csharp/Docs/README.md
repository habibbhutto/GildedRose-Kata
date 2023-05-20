# Assumptions

* Item is a service contract, a data model that is used to integrate with Goblin's system.
* We must not modify the item, othrewise it can break the integration

# Design

The item is treated as data model that is used as service contract for integration purpose. 
Hence, we have developed InventoryItem, an appropriate concept in the context of GildedRose.
InventoryItem is a domain entity that has its own operation, it is composed on top of Item.

We have simplified GildedRose down to two simplified operations named based on GildedRose 
business terminologies. The UpdateQuality() method in it iterates over the InventoryItems list
and calls UpdateQuality() on each item.

As InventoryItem is composed on top of Item, so it has its own operation that perform operations
on Item's properties such as SellIn and Quality. We have introduced the term Expiry to keep it 
in line with day to day business terminology. When UpdateQuality() is called on an inventory item.
It gets the applicable policy for it, and applies it on inventory item by calling policy's 
execute() method.

We have introduced the Policies module, it is to make the policies extendable, so that we can
keep up with the growth of the business. The term policies/policy is used to keep aligned with 
business terminologies. These requirements are technically quality policies in the context of 
GildedRose business.

The design of Policies and its integration with InventoryItem is inspired by Strategy and State 
design patterns. It's not typical Strategy or State.

This design has benefits over typical inheritence based polymorphism because it's based on the 
concpept of composition. We can compose new policies by leveraging existing ones. In addition, 
a policy can be used for multiple item categories in Policies configuration.

The PolicyNames in constants are added to avoid potential bugs caused by magic strings.

The tests are moved to Tests folder so that they have their own home for better organization.
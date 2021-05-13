## Gilded Rose Requirements

- Once the sell by date has passed, Quality degrades twice as fast
- The Quality of an item is never negative
- "Aged Brie" actually increases in Quality the older it gets
- The Quality of an item is never more than 50
- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;<br>
Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert

We have recently signed a supplier of conjured items. This requires an update to our system:

- "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any new code as long as everything
still works correctly. However, do not alter the ***Item class*** or ***Items property*** as those belong to the
goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code
ownership.

Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a
legendary item and as such its Quality is 80 and it never alters.

## Steps to reproduce

```
git clone --depth 1 --filter=blob:none --sparse https://github.com/emilybache/GildedRose-Refactoring-Kata
cd GildedRose-Refactoring-Kata
git sparse-checkout set csharp
cd csharp
git init
git add --all
git commit
git remote add origin https://github.com/{username}/GildedRose_refactoring-Kata.git
git push -u origin main
```

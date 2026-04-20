# Ch08Ex1GuitarShop

This project is the Guitar Shop app updated for the chapter 8 exercise. I made a ProductsViewModel class so the product list pages use a view model instead of ViewBag for the categories and selected category. I updated both the main Product List page and the Admin Product List page to use that model.

I also added TempData messages so the app shows feedback when a product or category is added, updated, or deleted. The cart add action now sends the user back to the Product List page and shows a message there instead of using the old add view message.

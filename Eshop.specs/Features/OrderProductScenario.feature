Feature: OrderProductScenario

A short summary of the feature
    
	@OrderProduct
	@Edge
Scenario: Order a product
	Given Users navigate to the HomePage
	When Users navigate to the login page
		And Users enters a valid credentials,with input email "demouser@microsoft.com" and password "Pass@word1"
		And Users clicks on login
		And Users is redirected to HomePage where the user's email "demouser@microsoft.com" will appear on the Navbar
		And User select other from the brand dropdown
		And User click on apply the filter button
       Then User adds a product to cart
         And User select "2" as quantity
         And User updates click on the update cart button
         And User clicks on the checkout button
         And User clicks on paynow button
         And User view the confirmation message
         And User navigates to the orders page and view the order details

		 @OrderProductInvalidQuantity
Scenario: Order a product with invalid quantity
	Given Users navigate to the HomePage
	When Users navigate to the login page
		And Users enters a valid credentials,with input email "demouser@microsoft.com" and password "Pass@word1"
		And Users clicks on login
		And Users is redirected to HomePage where the user's email "demouser@microsoft.com" will appear on the Navbar
		And User select other from the brand dropdown
		And User click on apply the filter button
       Then User adds a product to cart
         And User select "10000000000" as quantity
         And User click on update cart (with assert)


		 	@OrderSeveralProducts
Scenario: Order 5 product for a single user
	Given Users navigate to the HomePage
	When Users navigate to the login page
		And Users enters a valid credentials,with input email "demouser@microsoft.com" and password "Pass@word1"
		And Users clicks on login
		Then Users Add product to cart
	   | ProductName                | Quantity |
	   | PRISM WHITE T-SHIRT        | 5        |
	   | .NET FOUNDATION SWEATSHIRT | 2        |
	   | .NET BOT BLACK SWEATSHIRT  | 7        |
       |    CUP<T> WHITE MUG        | 3        |
       |    ROSLYN RED T-SHIRT      | 9        |
	   And go back to cart to proceed to checkout
	   And User clicks on the checkout button
		And User clicks on paynow button
		And User view the confirmation message
		And User navigates to the orders page and view the order details
		And verify purchase
	   | ProductName                | Quantity |
	   | PRISM WHITE T-SHIRT        | 5        |
	   | .NET FOUNDATION SWEATSHIRT | 2        |
	   | .NET BOT BLACK SWEATSHIRT  | 7        |
       |    CUP<T> WHITE MUG        | 3        |
       |    ROSLYN RED T-SHIRT      | 9        |
	
       







	     
		  

Users
=========

## Sign in
#### Test steps
* Open Home Page
* Click on Sign in button
* Fill Email address to create an account
* Click Create an account
* Fill all fields with correct data
* Click Register Button
#### Assertions
* My account page is opened
* Proper username is shown in the header
* Log out action is available

## Log in
#### Preconditions
Tags: registered
* Existing customer
#### Test steps
* Open Home Page
* Click on Sign in button
* Fill Email address in Already registered block
* Fill Password in Already registered block
* Click on Sign in
#### Assertions
* My account page is opened
* Proper username is shown in the header
* Log out action is available

## Checkout
#### Preconditions
* Existing customer
* Order details
#### Test steps
* Log in as existing customer
* Click "Women" button in the header
* Click the product with name "Faded Short Sleeve T-shirts"
* Click Add to cart
* Click on Proceed to checkout button on Modal
* Click on Proceed to checkout button on summary step
* Click on Proceed to checkout button on address step
* Click by Terms of service to agree
* Click on Proceed to checkout button on shipping step
* Click by payment method Pay by bank wire
* Click I confirm my order
#### Assertions
* Order confirmation page is opened
* The order is complete
* Current page is the last step of ordering
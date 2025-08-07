Feature: Search

# Scenario: Verify Address or City search successfully returns a location
#     Given I navigate to "https://www.anytimemailbox.com/"
#     When I input "Manila" into the address field
#     And I click the address field "Manila, Philippines"
#     Then The location displayed should be "Taguig"

# Scenario: Verify Address or City DOES NOT return a location
#     Given I navigate to "https://www.anytimemailbox.com/"
#     When I input "Cebu" into the address field
#     And I click the address field "Cebu City, Philippines"
#     Then The location displayed should be "Cebu"

Scenario: Verify Login Fails
    Given I navigate to "https://www.anytimemailbox.com/"
    When I click the Login button
    And I input not valid email in the Email field
    And I input not valid password in the Password field
    And I click the Log In
    And I click the reCAPTCHA checkbox
    Then The error message for invalid credentials should be displayed
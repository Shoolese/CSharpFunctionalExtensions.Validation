# Usage:
```
var str = "This is a string to validate
var validationResult = str.IsNotNull().IsParseableToGuid().DoesNotContainAnyCapitalLetters().Validate();
if (validationResult.IsFailure)
  return Nope();
```


#Todo :

| #     | Desc                                                                                                      | 
|-------|-----------------------------------------------------------------------------------------------------------|
| 1     | Don't have many rules in here at all really - First session would probably be find more validation rules  |

import sys
import json

# Define the starting function
def my_function(param1, param2):
    result = json.dumps({"param1": param1, "param2": param2})
    return result

# The program will start here
if __name__ == "__main__":
    # Verify if there are enough arguments
    if (len(sys.argv) != 4):
        print("PyScriptError: Invalid number of arguments.")
        # Return statement is not valid outside of a function
        # Consider using sys.exit() to terminate the script
        sys.exit(1)

    # Argv[0] is the name of the script
    # Argv[1] is the name of the function
    # Argv[2] is the first parameter
    # Argv[3] is the second parameter

    if sys.argv[1] != "my_function":
        print("PyScriptError: Wrong function name.")
        sys.exit(1)

    # Get the arguments
    parameter1 = sys.argv[2]
    parameter2 = sys.argv[3]

    # Call the function with the arguments
    resultado = my_function(parameter1, parameter2)

    # Print the result to capture it by the C#
    print(resultado)
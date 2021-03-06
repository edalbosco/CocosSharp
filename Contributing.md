Contributing to CocosSharp
==========================

We encourage you to contribute to the CocosSharp repository. Your
involvement is important to the success of the project.

There are some style guidelines you must follow if you want your Pull
Request to be accepted:

1. Follow the .NET Design guidelines. 

2. Make use of partial classes to implement the platform specific
nuances of a feature.

3. Very little idiomatic coding, meaning no #if XYA #endif code
blocks.

4. Document your methods and features.

5. No magic numbers. Create const members for static literals and
document their use.

6. No unnecessary object instantiation to pass simple literals as
parameters.

7. Use CCxxx as your class names for framework classes.

8. Maintain the single level namespace "Cocos2D/ALL_CLASSES_HERE"

9. If you use our graphics, use them in the format that we give
you. You are allowed to use the graphics, logos, etc., but you can not
deface them or place your logo atop of our logos.

10. Solution files are CocosSharp.Platform.sln. Platform is named
such as Windows, WindowsGL, etc.

11. Project files are CocosSharp.Platform.csproj, see #10.

12. All output must go through CCLog.Log()

13. Assert only using Debug.Assert()

14. Your pull request must be atomic. Do not stack many bug fixes into
a single PR.

15. Avoid unnecessary virtual method signatures. Virtual methods are
significantly slower than non-virtual methods.

16. No self-factory patterns. Use typed constructors to create the
state of an object.

17. Use triangle strip if at all possible. Only use a triangle list
when you can't organize the polygons in a strip.

By following these rules, the framework will continue to grow in a
robust and stable manner that helps all of the developers to create
great software.

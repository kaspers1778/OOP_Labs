namespace OOP_LAB_1
{/// <Summary>
 /// Abstract creator class declares the factory method,creats an object of 
 /// some concrete product.
 /// </Summary>
    abstract class Realization
    {
           /// <Summary>
            /// Factory method creates general IDeck object.
            /// </Summary>
        abstract public IDeck Create();
    }
        
    


}

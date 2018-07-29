namespace hotel
{
    abstract class building
    {
        public building(int numOfStoreys,bool Elevator)
        {
            NumberOfStoreysInTheBuilding = numOfStoreys;
            IsThereAnElevator = Elevator;
        }
        public int NumberOfStoreysInTheBuilding; 
        public bool IsThereAnElevator;

        virtual public string GetDetails() {
            return ($"NumberOfStoreysInTheBuilding {NumberOfStoreysInTheBuilding} \nIsThereAnElevator{IsThereAnElevator}"); 
        }
        
    }
}
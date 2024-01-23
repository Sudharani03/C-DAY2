using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Assignment2_Doctors.Interfaces
{
    /// <summary>
    /// Represents a interface with CRUD Operations
    /// </summary>
    /// <typeparam name="K">Type of Key used to identify items in repository </typeparam>
    /// <typeparam name="T">Represents DataType of items stored in repository </typeparam>
    public interface IDoctorRepository<K, T>
    {
        /// <summary>
        /// Adds an item to repository
        /// </summary>
        /// <param name="item">Item to be added</param>
        /// <returns>Returns added item , or null if unsuccessful</returns>
        T? Add(T item);

        /// <summary>
        /// Retrieves an item from repository based on key
        /// </summary>
        /// <param name="key">Key used to identify item</param>
        /// <returns>Returns the item if successfull , otherwise null</returns>
        T? Get(K key);

        /// <summary>
        /// Retrieves all the items from repository
        /// </summary>
        /// <returns>Returns list of items in repository if present , otherwise null</returns>
        List<T> GetAll();

        /// <summary>
        /// Updates an item in repository
        /// </summary>
        /// <param name="item">The item with updated information </param>
        /// <returns>Returns Updated item if present , otherwise null</returns>
        T? Update(T item);

        /// <summary>
        /// Deletes an item from repository based on key
        /// </summary>
        /// <param name="key">Key used to identify item to be deleted</param>
        /// <returns>Returns deleted item if present , otherwise null </returns>
        T? Delete(K key);
    }
}

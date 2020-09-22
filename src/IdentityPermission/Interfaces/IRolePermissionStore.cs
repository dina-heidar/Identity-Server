﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.IdentityPermission
{
    public interface IRolePermissionStore<TRole, TPermission> //: IQueryableRolePermissionStore<TPermission>
        where TPermission : class
         where TRole : class
    {
        /// <summary>
        /// Add the specified <paramref name="permission"/> to the named role.
        /// </summary>
        /// <param name="permission">The permission to add to the named role.</param>
        /// <param name="roleName">The name of the role to add the permission to.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        Task AddToRoleAsync(TPermission permission, TRole role, CancellationToken cancellationToken);

        /// <summary>
        /// Remove the specified <paramref name="permission"/> from the named role.
        /// </summary>
        /// <param name="permission">The permission to remove the named role from.</param>
        /// <param name="roleName">The name of the role to remove.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        Task RemoveFromRoleAsync(TPermission permission, TRole rolen, CancellationToken cancellationToken);

        /// <summary>
        /// Gets a list of role names the specified <paramref name="permission"/> belongs to.
        /// </summary>
        /// <param name="permission">The permission whose role names to retrieve.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing a list of role names.</returns>
        Task<IList<string>> GetRolesAsync(TPermission permission, CancellationToken cancellationToken);

        /// <summary>
        /// Returns a flag indicating whether the specified <paramref name="permission"/> is a member of the given named role.
        /// </summary>
        /// <param name="permission">The permission whose role membership should be checked.</param>
        /// <param name="roleName">The name of the role to be checked.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation, containing a flag indicating whether the specified <paramref name="user"/> is
        /// a member of the named permission.
        /// </returns>
        Task<bool> IsInRoleAsync(TPermission permission, string roleName, CancellationToken cancellationToken);

        /// <summary>
        /// Returns a list of Permission who are members of the named role.
        /// </summary>
        /// <param name="roleName">The name of the role whose membership should be returned.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation, containing a list of users who are in the named role.
        /// </returns>
        Task<IList<TPermission>> GetRoleInPermissionsAsync(string roleName, CancellationToken cancellationToken);
    }
}
package com.lg;

import com.google.common.io.ByteStreams;
import com.lg.entities.Role;
import com.lg.entities.User;
import com.lg.entities.UsersGroup;
import com.lg.models.Sex;
import jakarta.persistence.EntityManager;
import jakarta.persistence.EntityManagerFactory;
import jakarta.persistence.Persistence;
import jakarta.persistence.Query;

import java.io.IOException;
import java.io.InputStream;

public class Main {
    private static EntityManager em;

    public static void main(String[] args) throws IOException {
        System.out.println("JPA project");
        EntityManagerFactory factory = Persistence.createEntityManagerFactory("Hibernate_JPA");
        em = factory.createEntityManager();

        task3();
        task4();
        task5();

        em.close();
        factory.close();
    }

    private static void addUsers() {
        em.getTransaction().begin();
        User u1 = new User("test_1", "pass", "Andrzej", "Kowalski", Sex.MALE);
        User u2 = new User("test_2", "pass", "Adam", "Kowalski", Sex.MALE);
        User u3 = new User("test_3", "pass", "Lara", "Kaczmarczyk", Sex.FEMALE);
        User u4 = new User("test_4", "pass", "Eliza", "Mroz", Sex.FEMALE);
        User u5 = new User("test_5", "pass", "Kazimierz", "Czarnecki", Sex.MALE);
        em.persist(u1);
        em.persist(u2);
        em.persist(u3);
        em.persist(u4);
        em.persist(u5);
        em.getTransaction().commit();
    }

    private static void addRoles() {
        em.getTransaction().begin();
        Role role1 = new Role("role_1");
        Role role2 = new Role("role_2");
        Role role3 = new Role("role_3");
        Role role4 = new Role("role_4");
        Role role5 = new Role("role_5");
        em.persist(role1);
        em.persist(role2);
        em.persist(role3);
        em.persist(role4);
        em.persist(role5);
        em.getTransaction().commit();
    }

    private static void task3() {
        addUsers();
        addRoles();

        // Zmiana hasła użytkownika o id = '1'
        em.getTransaction().begin();
        User user = em.find(User.class, 1);
        user.setPassword("new_password");
        em.merge(user);
        em.getTransaction().commit();

        // Usunięcie roli o id = '5'
        em.getTransaction().begin();
        Role role = em.find(Role.class, 5);
        em.remove(role);
        em.getTransaction().commit();

        // Lista użytkowników o nazwisku 'Kowalski'
        em.getTransaction().begin();
        Query query1 = em.createQuery("SELECT u FROM User u WHERE u.lastName = 'Kowalski'");
        var kowalscy = query1.getResultList();
        System.out.println("Kowalscy");
        for (var kowalski : kowalscy) {
            System.out.println(kowalski);
        }
        em.getTransaction().commit();

        // Lista wszystkich kobiet
        em.getTransaction().begin();
        Query query2 = em.createQuery("SELECT u FROM User u WHERE u.sex = 'FEMALE'");
        var women = query2.getResultList();
        System.out.println("Kobiety");
        for (var woman : women) {
            System.out.println(woman);
        }
        em.getTransaction().commit();
    }

    private static void task4() {
        // Add user with 2 roles
        em.getTransaction().begin();
        var u = new User("test_10", "pass", "Dariusz", "Kowalski", Sex.MALE);
        var role1 = em.find(Role.class, 1);
        var role2 = em.find(Role.class, 2);
        u.addRole(role1);
        u.addRole(role2);
        em.persist(u);
        em.getTransaction().commit();

        // Add UserGroups
        em.getTransaction().begin();
        var usersGroup1 = new UsersGroup(1);
        var usersGroup2 = new UsersGroup(2);
        var usersGroup3 = new UsersGroup(3);
        em.merge(usersGroup1);
        em.merge(usersGroup2);
        em.merge(usersGroup3);
        em.getTransaction().commit();

        // Add users to UserGroups
        em.getTransaction().begin();
        var user1 = em.find(User.class, 1);
        user1.addUsersGroup(usersGroup1);
        user1.addUsersGroup(usersGroup2);
        var user2 = em.find(User.class, 2);
        user2.addUsersGroup(usersGroup1);
        user2.addUsersGroup(usersGroup3);
        var user3 = em.find(User.class, 3);
        user3.addUsersGroup(usersGroup1);
        user3.addUsersGroup(usersGroup2);
        user3.addUsersGroup(usersGroup3);
        em.merge(user1);
        em.merge(user2);
        em.merge(user3);
        em.getTransaction().commit();
    }

    private static void task5() throws IOException {
        em.getTransaction().begin();
        byte[] photo = readFile("/tucan.jpg");
        var u = new User("user_with_photo", "pass", "Pelican", "Bird", Sex.MALE);
        u.setPhoto(photo);
        em.persist(u);
        em.getTransaction().commit();
    }

    public static byte[] readFile(String fileName) throws IOException {
        InputStream inputStream = Main.class.getResourceAsStream(fileName);
        assert inputStream != null;
        return ByteStreams.toByteArray(inputStream);
    }
}
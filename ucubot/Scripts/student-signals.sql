use ucubot;
CREATE VIEW student_signals as SELECT student.first_name, student.last_name,
    (CASE lesson_signal.signal_type
    WHEN -1 THEN "Simple"
    WHEN 0 THEN "Normal"
    WHEN 1 THEN "Hard" END) as signal_type,
    COUNT(lesson_signal.student_id) AS cont FROM student JOIN (lesson_signal) ON (lesson_signal.student_id = student.id)
    GROUP BY lesson_signal.signal_type, student.id;
